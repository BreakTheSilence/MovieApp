namespace MovieApp.Messaging.Interfaces.Services;

public interface IMessagePublisher
{
    Task<string> PublishMovieListRequest(string request);
}