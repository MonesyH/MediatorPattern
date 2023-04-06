namespace MediatorPattern;

// 具体同事类1
internal class ConcreteColleague1 : IColleague
{
    private readonly IMediator _mediator;

    public ConcreteColleague1(IMediator mediator)
    {
        this._mediator = mediator;
    }

    public void SendMessage(string message)
    {
        _mediator.SendMessage(message, this);
    }

    public void ReceiveMessage(string message)
    {
        Console.WriteLine("ConcreteColleague1 received message: " + message);
    }
}

// 具体同事类2
internal class ConcreteColleague2 : IColleague
{
    private readonly IMediator _mediator;

    public ConcreteColleague2(IMediator mediator)
    {
        this._mediator = mediator;
    }

    public void SendMessage(string message)
    {
        _mediator.SendMessage(message, this);
    }

    public void ReceiveMessage(string message)
    {
        Console.WriteLine("ConcreteColleague2 received message: " + message);
    }
}

// 具体中介者类
internal class ConcreteMediator : IMediator
{
    private readonly List<IColleague> _colleagues = new List<IColleague>();

    public void AddColleague(IColleague colleague)
    {
        _colleagues.Add(colleague);
    }

    public void SendMessage(string message, IColleague sender)
    {
        foreach (var colleague in _colleagues.Where(colleague => colleague != sender))
        {
            colleague.ReceiveMessage(message);
        }
    }
}

// 示例代码
class Program
{
    private static void Main(string[] args)
    {
        var mediator = new ConcreteMediator();
        var colleague1 = new ConcreteColleague1(mediator);
        var colleague2 = new ConcreteColleague2(mediator);

        mediator.AddColleague(colleague1);
        mediator.AddColleague(colleague2);

        colleague1.SendMessage("Hello from ConcreteColleague1.");
        colleague2.SendMessage("Hello from ConcreteColleague2.");

        Console.ReadKey();
    }
}