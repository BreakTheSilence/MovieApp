using RabbitMQ.Client.Events;

namespace MovieApp.Messaging.Interfaces.Services;

public interface IMessageListener
{
    void Start(Func<string, string> messageHandler);
}