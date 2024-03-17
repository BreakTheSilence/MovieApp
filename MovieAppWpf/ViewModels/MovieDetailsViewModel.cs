using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MovieApp.Messaging.Interfaces.Services;
using MovieAppWpf.Interfaces;
using MovieAppWpf.ViewModels.Controls;

namespace MovieAppWpf.ViewModels;

public class MovieDetailsViewModel : ObservableObject
{
    private readonly IMessagePublisher _messagePublisher;
    private readonly INavigationService _navigationService;

    private int _movieId;
    private MovieDetailsControlViewModel _movieDetailsControlViewModel;

    public MovieDetailsViewModel(IMessagePublisher messagePublisher, 
        INavigationService navigationService)
    {
        _messagePublisher = messagePublisher;
        _navigationService = navigationService;
        PageLoadedCommand = new AsyncRelayCommand(PageLoaded);
        GoBackCommand = new RelayCommand(GoBack);
    }
    
    public ICommand PageLoadedCommand { get; }
    public ICommand GoBackCommand { get; }

    public MovieDetailsControlViewModel MovieDetailsControlViewModel
    {
        get => _movieDetailsControlViewModel;
        set => SetProperty(ref _movieDetailsControlViewModel, value);
    }

    public void Initialize(int movieId)
    {
        _movieId = movieId;
    }
    
    private async Task PageLoaded()
    {
        var movieDto = await _messagePublisher.GetMovieDetailsAsync(_movieId);
        MovieDetailsControlViewModel = new MovieDetailsControlViewModel(movieDto);
    }

    private void GoBack()
    {
        _navigationService.GoBack();
    }
}