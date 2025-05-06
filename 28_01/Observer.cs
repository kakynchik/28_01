namespace _28_01;

public interface IObserver
{
    void Update(string message);
}

public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

public class TaskSubject : ISubject
{
    private List<IObserver> _observers = new List<IObserver>();
    private string _state;

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_state);
        }
    }

    public void SetState(string state)
    {
        _state = state;
        Notify();
    }
}

public class TaskObserver : IObserver
{
    private string _name;

    public TaskObserver(string name)
    {
        _name = name;
    }

    public void Update(string message)
    {
        Console.WriteLine($"{_name} received update: {message}");
    }
}