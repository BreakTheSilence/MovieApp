using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using MovieAppWpf.Interfaces;

namespace MovieAppWpf.Services;

public class NavigationService : INavigationService
{
    private readonly IServiceProvider _serviceProvider;
    private Frame _mainFrame;

    public NavigationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void Initialize(Frame frame)
    {
        _mainFrame = frame;
    }

    public void Navigate<TViewModel>() where TViewModel : ObservableObject
    {
        var viewType = ViewLocator.GetViewTypeForViewModel(typeof(TViewModel));
        var view = (Page)_serviceProvider.GetService(viewType);

        // Получаем ViewModel из DI контейнера.
        var viewModel = _serviceProvider.GetRequiredService<TViewModel>();

        // Устанавливаем DataContext для View.
        view.DataContext = viewModel;

        // Выполняем навигацию.
        _mainFrame.Navigate(view);
    }

    public void GoBack()
    {
        throw new NotImplementedException();
    }
}