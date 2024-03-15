using Domain.Models;
using MovieApp.DAL.Interfaces.Repositories;

namespace MovieApp.DAL.Repositories;

public class MovieRepository : IMovieRepository
{
    public IEnumerable<Movie> GetAllMovies()
    {
        throw new NotImplementedException();
    }

    public Movie GetMovieById(int id)
    {
        throw new NotImplementedException();
    }
}