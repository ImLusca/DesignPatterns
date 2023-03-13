namespace design.LibraryExample.implementation;

public interface IRenters
{
    public void addProducts(List<IProduct> products);
    public IProduct? borrowProduct(string productName);
    public int countListningObservers();

    public string establishmentName { get; }
    public string product {get;}
}