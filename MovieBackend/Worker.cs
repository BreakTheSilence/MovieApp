using MovieApp.Messaging.Interfaces.Services;

namespace MovieBackend;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IMessageHandlerService _messageHandlerService;
    private readonly IMessageListener _messageListener;

    public Worker(ILogger<Worker> logger, IMessageListener messageListener,
        IMessageHandlerService messageHandlerService)
    {
        _logger = logger;
        _messageListener = messageListener;
        _messageHandlerService = messageHandlerService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();
        _messageListener.Start(_messageHandlerService, stoppingToken);

        while (!stoppingToken.IsCancellationRequested) await Task.Delay(1000, stoppingToken);
    }
}