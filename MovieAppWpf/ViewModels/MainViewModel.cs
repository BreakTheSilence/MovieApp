using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MovieAppWpf.Interfaces;
using MovieAppWpf.Views;

namespace MovieAppWpf.ViewModels;

public class MainViewModel : ObservableObject
{
    private readonly INavigationService _navigationService;

    public MainViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;

        NavigateToMoviesCommand = new RelayCommand(NavigateToMovies);
    }

    public ICommand NavigateToMoviesCommand { get; }


    private void NavigateToMovies()
    {
        _navigationService.Navigate<MoviesViewModel>();
    }
}