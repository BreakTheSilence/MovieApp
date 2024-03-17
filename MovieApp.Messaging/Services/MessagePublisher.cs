using System.Text;
using Domain;
using Domain.DTO;
using Domain.Models;
using MovieApp.Messaging.Interfaces;
using MovieApp.Messaging.Interfaces.Services;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace MovieApp.Messaging.Services;

public class MessagePublisher : IMessagePublisher
{
    private readonly IRabbitMqConfiguration _rabbitMqConfiguration;

    public MessagePublisher(IRabbitMqConfiguration rabbitMqConfiguration)
    {
        _rabbitMqConfiguration = rabbitMqConfiguration;
    }

    public async Task<IEnumerable<MovieDto>> GetAllMoviesAsync()
    {
        var response = await PublishRequest(Enums.RequestType.GetAllMovies.ToString());
        var serialized = JsonConvert.DeserializeObject<IEnumerable<MovieDto>>(response);
        if (serialized is null) throw new ArgumentException("Could not serialize response");
        return serialized;
    }

    public async Task<MovieDetailsDto> GetMovieDetailsAsync(int movieId)
    {
        var response = await PublishRequest(Enums.RequestType.GetMovieDetails.ToString(), movieId);
        var serialized = JsonConvert.DeserializeObject<MovieDetailsDto>(response);
        if (serialized is null) throw new ArgumentException("Could not serialize response");
        return serialized;
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        var response = await PublishRequest(Enums.RequestType.GetCategories.ToString());
        var serialized = JsonConvert.DeserializeObject<IEnumerable<Category>>(response);
        if (serialized is null) throw new ArgumentException("Could not serialize response");
        return serialized;
    }

    private async Task<string> PublishRequest(string request, int parameter = -1)
    {
        var factory = new ConnectionFactory { HostName = _rabbitMqConfiguration.Hostname };
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

        var messageBytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(parameter));
        channel.BasicPublish(
            "",
            request,
            properties,
            messageBytes);

        return await tcs.Task;
    }
}