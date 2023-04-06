namespace MediatorPattern;

public interface IMediator
{
    void SendMessage(string message, IColleague colleague);
}