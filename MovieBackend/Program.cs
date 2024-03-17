using MovieApp.DAL.Interfaces.Repositories;
using MovieApp.DAL.Repositories;
using MovieApp.Messaging;
using MovieApp.Messaging.Interfaces;
using MovieApp.Messaging.Interfaces.Services;
using MovieApp.Messaging.Services;
using MovieBackend;
using MovieBackend.Interfaces.Services;
using MovieBackend.Services;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IMovieRepository, MovieRepository>();
        services.AddTransient<IMovieService, MovieService>();
        services.AddTransient<ICategoryService, CategoryService>();
        services.AddSingleton<IMessageListener, MessageListener>();
        services.AddSingleton<IRabbitMqConfiguration, RabbitMqConfiguration>();
        services.AddSingleton<IMessageListener, MessageListener>();
        services.AddSingleton<IMessageHandlerService>(provider =>
        {
            var movieService = provider.GetRequiredService<IMovieService>();
            var categoryService = provider.GetRequiredService<ICategoryService>();
            return new MessageHandlerService(movieService.GetMovies, movieService.GetMovieById,
                categoryService.GetCategories);
        });
        services.AddHostedService<Worker>();
        services.AddWindowsService(options => { options.ServiceName = "MovieApp Windows Service"; });
    })
    .Build();

await host.RunAsync();