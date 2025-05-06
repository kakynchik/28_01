namespace _28_01;

public interface IMediator
{
    void Notify(object sender, string ev);
}

public class TaskMediator : IMediator
{
    private List<Component> _components = new List<Component>();

    public void Register(Component component)
    {
        _components.Add(component);
        component.SetMediator(this);
    }

    public void Notify(object sender, string ev)
    {
        foreach (var component in _components)
        {
            if (component != sender)
            {
                component.Receive(ev);
            }
        }
    }
}

public abstract class Component
{
    protected IMediator _mediator;

    public void SetMediator(IMediator mediator)
    {
        _mediator = mediator;
    }

    public abstract void Send(string message);
    public abstract void Receive(string message);
}

public class TaskComponent : Component
{
    public override void Send(string message)
    {
        Console.WriteLine($"Task sends: {message}");
        _mediator.Notify(this, message);
    }

    public override void Receive(string message)
    {
        Console.WriteLine($"Task received: {message}");
    }
}