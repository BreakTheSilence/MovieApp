namespace MovieApp.Messaging.Interfaces;

public interface IRabbitMqConfiguration
{
    string Hostname { get; }
    string QueueName { get; }
    string ReplyQueueName { get; }
}