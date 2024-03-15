using Domain.Models;
using MovieApp.DAL.Interfaces.Repositories;
using MovieBackend.Interfaces.Services;

namespace MovieBackend.Services;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;

    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }
    
    public IEnumerable<Movie> GetMovies()
    {
        return _movieRepository.GetAllMovies();
    }

    public Movie GetMovieById(int id)
    {
        return _movieRepository.GetMovieById(id);
    }
}