using MovieBackend.Interfaces.Services;

namespace MovieBackend.Services;

public class MessageHandlerService : IMessageHandlerService
{
    private readonly IMovieService _movieService;
    private readonly ICategoryService _categoryService;

    public MessageHandlerService(IMovieService movieService, ICategoryService categoryService)
    {
        _movieService = movieService;
        _categoryService = categoryService;
    }
    
    public string HandleRequest(string requestMessage)
    {
        var a = requestMessage;
        return a;
    }
}