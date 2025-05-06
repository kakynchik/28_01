namespace _28_01;

class Program
{
    static void Main(string[] args)
    {
        var mediator = new TaskMediator();
        var task1 = new TaskComponent();
        var task2 = new TaskComponent();

        mediator.Register(task1);
        mediator.Register(task2);

        task1.Send("Hello from Task 1");
        
        var task = new Task("Initial State");
        var caretaker = new Caretaker();

        caretaker.AddMemento(task.SaveState());

        task.SetState("New State");
        caretaker.AddMemento(task.SaveState());

        task.RestoreState(caretaker.GetMemento(0));
        Console.WriteLine($"Restored State: {task.GetState()}");
        
        var subject = new TaskSubject();
        var observer1 = new TaskObserver("Observer 1");
        var observer2 = new TaskObserver("Observer 2");

        subject.Attach(observer1);
        subject.Attach(observer2);

        subject.SetState("Task State Updated");
    }
}