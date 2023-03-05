namespace design.LibraryExample.implementation;

public abstract class IObserver
{
    public abstract void update();
    protected Boolean isSubscribed;
}