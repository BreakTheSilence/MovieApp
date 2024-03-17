using Domain.DTO;
using Domain.Models;
using MovieApp.Messaging.Interfaces.Services;
using Newtonsoft.Json;

namespace MovieApp.Messaging.Services;

public class MessageHandlerService : IMessageHandlerService
{
    private readonly Func<IEnumerable<Category>> _getAllCategories;
    private readonly Func<IEnumerable<Movie>> _getAllMovies;
    private readonly Func<int, Movie> _getMovieById;

    public MessageHandlerService(Func<IEnumerable<Movie>> getAllMovies, Func<int, Movie> getMovieById,
        Func<IEnumerable<Category>> getAllCategories)
    {
        _getAllMovies = getAllMovies;
        _getMovieById = getMovieById;
        _getAllCategories = getAllCategories;
    }

    public string HandleAllMoviesRequest()
    {
        var allMovies = _getAllMovies();
        var allCategories = _getAllCategories().ToList();
        var allMoviesDto = new List<MovieDto>();
        foreach (var movie in allMovies)
            allMoviesDto.Add(new MovieDto
            {
                Id = movie.Id,
                Category = allCategories.First(c => c.Id.Equals(movie.CategoryId)),
                Rating = movie.Rating,
                Title = movie.Title,
                Year = movie.Year
            });
        return JsonConvert.SerializeObject(allMoviesDto);
    }

    public string HandleMovieDetailsRequest(int movieId)
    {
        var movie = _getMovieById(movieId);
        var allCategories = _getAllCategories().ToList();

        return JsonConvert.SerializeObject(new MovieDetailsDto
        {
            Id = movie.Id,
            Category = allCategories.First(c => c.Id.Equals(movie.CategoryId)),
            Rating = movie.Rating,
            Title = movie.Title,
            Description = movie.Description,
            Year = movie.Year
        });
    }

    public string HandleAllCategoriesRequest()
    {
        return JsonConvert.SerializeObject(_getAllCategories());
    }
}