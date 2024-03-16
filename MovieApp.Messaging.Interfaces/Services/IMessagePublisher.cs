using Domain.DTO;
using Domain.Models;

namespace MovieApp.Messaging.Interfaces.Services;

public interface IMessagePublisher
{
    Task<IEnumerable<MovieDto>> GetAllMoviesAsync();
    Task<MovieDetailsDto> GetMovieDetailsAsync(int movieId);
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
}