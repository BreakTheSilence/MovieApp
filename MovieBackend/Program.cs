using MovieApp.DAL.Interfaces.Repositories;
using MovieApp.DAL.Repositories;
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
        services.AddHostedService<Worker>();
        services.AddWindowsService(options =>
        {
            options.ServiceName = "MovieApp Windows Service";
        });
    })
    .Build();

await host.RunAsync();