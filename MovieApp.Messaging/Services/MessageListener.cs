using System.Text;
using Domain;
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
    
    public void Start(IMessageHandlerService messageHandlerService, CancellationToken stoppingToken)
    {
        var factory = new ConnectionFactory() { HostName = _rabbitMqConfiguration.Hostname };
        var connection = factory.CreateConnection();
        
        HandleRequest(connection, Enums.RequestType.GetAllMovies, messageHandlerService);
        HandleRequest(connection, Enums.RequestType.GetMovieDetails, messageHandlerService);
        HandleRequest(connection, Enums.RequestType.GetCategories, messageHandlerService);

        while (!stoppingToken.IsCancellationRequested) { }
    }

    private void HandleRequest(IConnection connection, Enums.RequestType queueName, IMessageHandlerService messageHandlerService)
    {
        var channel = connection.CreateModel();

        channel.QueueDeclare(queue: queueName.ToString(), durable: false, exclusive: false, autoDelete: false, arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (_, ea) =>
        {
            var body = ea.Body.ToArray();
            var props = ea.BasicProperties;
            var replyProps = channel.CreateBasicProperties();
            replyProps.CorrelationId = props.CorrelationId;
            var message = Encoding.UTF8.GetString(body);

            string response;
            switch (queueName)
            {
                case Enums.RequestType.GetAllMovies:
                    response = messageHandlerService.HandleAllMoviesRequest();
                    break;
                case Enums.RequestType.GetMovieDetails:
                    if (!int.TryParse(message, out var id)) throw 
                        new ArgumentOutOfRangeException(message, "Could not parse movie id");
                    response = messageHandlerService.HandleMovieDetailsRequest(id);
                    break;
                case Enums.RequestType.GetCategories:
                    response = messageHandlerService.HandleAllCategoriesRequest();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(queueName), queueName, null);
            }

            var responseBytes = Encoding.UTF8.GetBytes(response);
            channel.BasicPublish(
                exchange: "",
                routingKey: props.ReplyTo,
                basicProperties: replyProps,
                body: responseBytes);
        };

        channel.BasicConsume(queue: queueName.ToString(), autoAck: true, consumer: consumer);
    }
}