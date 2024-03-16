using System.Text;
using System.Text.Json;
using MovieApp.Messaging.Interfaces;
using MovieApp.Messaging.Interfaces.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MovieApp.Messaging.Services;

public class MessagePublisher : IMessagePublisher
{
    private readonly IRabbitMqConfiguration _rabbitMqConfiguration;

    public MessagePublisher(IRabbitMqConfiguration rabbitMqConfiguration)
    {
        _rabbitMqConfiguration = rabbitMqConfiguration;
    }

    public async Task<string> PublishMovieListRequest(string request)
    {
        var factory = new ConnectionFactory() { HostName = _rabbitMqConfiguration.Hostname };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        var replyQueueName = channel.QueueDeclare().QueueName;
        var consumer = new EventingBasicConsumer(channel);
        var correlationId = Guid.NewGuid().ToString();

        var tcs = new TaskCompletionSource<string>();
        consumer.Received += (model, ea) =>
        {
            if (ea.BasicProperties.CorrelationId != correlationId) return;
            var response = Encoding.UTF8.GetString(ea.Body.ToArray());
            tcs.SetResult(response);
        };

        channel.BasicConsume(
            consumer: consumer,
            queue: replyQueueName,
            autoAck: true);

        var properties = channel.CreateBasicProperties();
        properties.CorrelationId = correlationId;
        properties.ReplyTo = replyQueueName;

        var messageBytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(request));
        channel.BasicPublish(
            exchange: "",
            routingKey: _rabbitMqConfiguration.QueueName,
            basicProperties: properties,
            body: messageBytes);

        return await tcs.Task;
    }
}