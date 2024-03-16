using MovieApp.Messaging.Interfaces;

namespace MovieApp.Messaging;

public class RabbitMqConfiguration : IRabbitMqConfiguration
{
    public string Hostname => "localhost";
    public string QueueName => "requestQueue";
    public string ReplyQueueName => "responseQueue";
}