using CommunityToolkit.Mvvm.ComponentModel;
using Domain.DTO;

namespace MovieAppWpf.ViewModels.Controls;

public class MovieDetailsControlViewModel : ObservableObject
{
    private MovieDetailsDto _movie;

    public MovieDetailsControlViewModel(MovieDetailsDto movie)
    {
        Movie = movie;
    }

    public MovieDetailsDto Movie
    {
        get => _movie;
        set => SetProperty(ref _movie, value);
    }

    public string RatingString => $"Rating: {Movie.Rating}/10";
    public string YearString => $"Year: {Movie.Year}";
    public string DescriptionString => $"Description:\n{Movie.Year}";
}