using Domain.Models;

namespace MovieApp.DAL.Interfaces.Repositories;

public interface IMovieRepository
{
    IEnumerable<Movie> GetAllMovies();
    Movie GetMovieById(int id);
}