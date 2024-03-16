using System.Windows;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.Messaging;
using MovieApp.Messaging.Interfaces;
using MovieApp.Messaging.Interfaces.Services;
using MovieApp.Messaging.Services;
using MovieAppWpf.ViewModels;

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
        // Configure your services here
        services.AddSingleton<IRabbitMqConfiguration, RabbitMqConfiguration>();
        services.AddTransient<IMessagePublisher, MessagePublisher>();
        // Add ViewModel registrations
        services.AddTransient<MainViewModel>();
        // Add other service registrations as needed
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        MainWindow = _serviceProvider.GetService<MainWindow>();
        MainWindow?.Show();
    }
}