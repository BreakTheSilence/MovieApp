using Domain.Models;

namespace MovieBackend.Interfaces.Services;

public interface IMovieService
{
    IEnumerable<Movie> GetMovies();
    Movie GetMovieById(int id);
}