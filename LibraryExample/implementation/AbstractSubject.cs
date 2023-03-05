namespace design.LibraryExample.implementation;

public abstract class Subject : ISubject
{
    protected HashSet<IObserver> observers = new HashSet<IObserver>();

    public void notify(){
        foreach(IObserver observer in observers){
            observer.update();
        }
    }

    public void registerObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void removeObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void removeAllObservers()
    {
        observers.Clear();
    }
}