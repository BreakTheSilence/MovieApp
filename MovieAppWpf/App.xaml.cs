using System.Windows;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.Messaging;
using MovieApp.Messaging.Interfaces;
using MovieApp.Messaging.Interfaces.Services;
using MovieApp.Messaging.Services;
using MovieAppWpf.Interfaces;
using MovieAppWpf.Services;
using MovieAppWpf.ViewModels;
using MovieAppWpf.Views;

namespace MovieAppWpf;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly IServiceProvider _serviceProvider;
    
    public App()
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        _serviceProvider = services.BuildServiceProvider();

        Ioc.Default.ConfigureServices(_serviceProvider);
    }
    
    private void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IRabbitMqConfiguration, RabbitMqConfiguration>();
        services.AddSingleton<INavigationService, NavigationService>();
        services.AddTransient<IMessagePublisher, MessagePublisher>();
        
        services.AddTransient<MainViewModel>();
        services.AddTransient<MoviesViewModel>();
        
        services.AddSingleton<MainWindow>();
        
        services.AddTransient<MoviesView>();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        MainWindow.DataContext = mainViewModel;
        MainWindow?.Show();
    }
}