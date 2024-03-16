using System.Text;
using System.Text.Json;
using MovieApp.Messaging.Interfaces;
using MovieApp.Messaging.Interfaces.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MovieApp.Messaging.Services;

public class MessageListener : IMessageListener
{
    private readonly IRabbitMqConfiguration _rabbitMqConfiguration;

    public MessageListener(IRabbitMqConfiguration rabbitMqConfiguration)
    {
        _rabbitMqConfiguration = rabbitMqConfiguration;
    }
    
    public void Start(Func<string, string> messageHandler)
    {
        var factory = new ConnectionFactory() { HostName = _rabbitMqConfiguration.Hostname };
        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

        channel.QueueDeclare(queue: _rabbitMqConfiguration.QueueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var props = ea.BasicProperties;
            var replyProps = channel.CreateBasicProperties();
            replyProps.CorrelationId = props.CorrelationId;
            var message = Encoding.UTF8.GetString(body);
            
            var response = messageHandler(message);

            var responseBytes = Encoding.UTF8.GetBytes(response);
            channel.BasicPublish(
                exchange: "",
                routingKey: props.ReplyTo,
                basicProperties: replyProps,
                body: responseBytes);
        };

        channel.BasicConsume(queue: _rabbitMqConfiguration.QueueName, autoAck: true, consumer: consumer);
        
        // TODO cancellation
        Console.ReadLine();
    }
}