namespace _28_01;

public class TaskMemento
{
    public string State { get; private set; }

    public TaskMemento(string state)
    {
        State = state;
    }
}

public class Task
{
    private string _state;

    public Task(string state)
    {
        _state = state;
    }

    public void SetState(string state)
    {
        _state = state;
    }

    public string GetState()
    {
        return _state;
    }

    public TaskMemento SaveState()
    {
        return new TaskMemento(_state);
    }

    public void RestoreState(TaskMemento memento)
    {
        _state = memento.State;
    }
}

public class Caretaker
{
    private List<TaskMemento> _mementos = new List<TaskMemento>();

    public void AddMemento(TaskMemento memento)
    {
        _mementos.Add(memento);
    }

    public TaskMemento GetMemento(int index)
    {
        return _mementos[index];
    }
}