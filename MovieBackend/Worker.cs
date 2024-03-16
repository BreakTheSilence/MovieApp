using MovieApp.Messaging.Interfaces.Services;
using MovieBackend.Interfaces.Services;

namespace MovieBackend;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger, IMessageListener messageListener, 
        IMessageHandlerService messageHandlerService)
    {
        _logger = logger;
        messageListener.Start(messageHandlerService.HandleRequest);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();
        
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(1000, stoppingToken);
        }
    }
}