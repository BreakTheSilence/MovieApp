using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MovieApp.Messaging.Interfaces.Services;
using MovieAppWpf.Interfaces;

namespace MovieAppWpf.ViewModels;

public class MoviesViewModel : ObservableObject
{
    private readonly IMessagePublisher _messagePublisher;
    private readonly INavigationService _navigationService;

    public MoviesViewModel(IMessagePublisher messagePublisher, INavigationService navigationService)
    {
        _messagePublisher = messagePublisher;
        _navigationService = navigationService;
        LoadCommand = new AsyncRelayCommand(GetAllMovies);
    }

    public ObservableCollection<MovieControlViewModel> Movies { get; set; } = new();

    public ICommand LoadCommand { get; set; }

    private async Task GetAllMovies()
    {
        var allMovies = await _messagePublisher.GetAllMoviesAsync();
        foreach (var movie in allMovies)
        {
            Movies.Add(new MovieControlViewModel(movie));
        }
    }
}