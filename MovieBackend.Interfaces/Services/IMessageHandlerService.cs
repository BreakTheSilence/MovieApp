namespace MovieBackend.Interfaces.Services;

public interface IMessageHandlerService
{
    string HandleRequest(string requestMessage);
}