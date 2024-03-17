using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using MovieAppWpf.Interfaces;
using MovieAppWpf.ViewModels;
using MovieAppWpf.Views;

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

        var viewModel = _serviceProvider.GetRequiredService<TViewModel>();

        view.DataContext = viewModel;

        _mainFrame.Navigate(view);
    }

    public void NavigateToMovieDetails(int movieId)
    {
        var view = _serviceProvider.GetRequiredService<MovieDetailsView>();
        var viewModel = _serviceProvider.GetRequiredService<MovieDetailsViewModel>();
        viewModel.Initialize(movieId);
        view.DataContext = viewModel;
        _mainFrame.Navigate(view);
    }

    public void GoBack()
    {
        if (_mainFrame.CanGoBack) _mainFrame.GoBack();
    }
}