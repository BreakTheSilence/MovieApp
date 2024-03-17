using CommunityToolkit.Mvvm.ComponentModel;
using Domain.DTO;

namespace MovieAppWpf.ViewModels.Controls;

public class MovieControlViewModel : ObservableObject
{
    public MovieControlViewModel(MovieDto movie)
    {
        Movie = movie;
    }

    public MovieDto Movie { get; }
}