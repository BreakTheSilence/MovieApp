namespace MovieApp.Messaging.Interfaces.Services;

public interface IMessageHandlerService
{
    string HandleAllMoviesRequest();
    string HandleMovieDetailsRequest(int movieId);
    string HandleAllCategoriesRequest();
}