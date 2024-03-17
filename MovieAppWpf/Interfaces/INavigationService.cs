using CommunityToolkit.Mvvm.ComponentModel;

namespace MovieAppWpf.Interfaces;

public interface INavigationService
{
    void Navigate<TViewModel>() where TViewModel : ObservableObject;
    void NavigateToMovieDetails(int movieId);
    void GoBack();
}