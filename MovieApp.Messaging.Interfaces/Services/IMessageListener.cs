using RabbitMQ.Client.Events;

namespace MovieApp.Messaging.Interfaces.Services;

public interface IMessageListener
{
    void Start(IMessageHandlerService messageHandlerService, CancellationToken stoppingToken);
}