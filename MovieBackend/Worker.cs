using MovieBackend.Interfaces.Services;

namespace MovieBackend;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IMovieService _movieService;
    private readonly ICategoryService _categoryService;

    public Worker(ILogger<Worker> logger, IMovieService movieService, ICategoryService categoryService)
    {
        _logger = logger;
        _movieService = movieService;
        _categoryService = categoryService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);
        }
    }
}