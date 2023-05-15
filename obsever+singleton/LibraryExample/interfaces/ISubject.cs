namespace design.LibraryExample.implementation;


public interface ISubject
{

    void registerObserver(IObserver observer);
    void removeObserver(IObserver observer);
    void removeAllObservers();
    void notify();
}