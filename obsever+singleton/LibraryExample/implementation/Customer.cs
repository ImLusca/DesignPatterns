namespace design.LibraryExample.implementation;

public class Customer : IObserver
{

    private IProduct? borrowedProduct;
    private String seekingProduct;

    public Customer(String product)
    {
        seekingProduct = product;
    }

    public void lookForBook(IRenters renter)
    {

        borrowedProduct = renter.borrowProduct(seekingProduct);

        if (borrowedProduct == null)
        {
            Console.WriteLine($"I didn't got the {seekingProduct} I'm looking for");
            if (!isSubscribed)
            {
                Console.WriteLine($"I will ask to the {renter.establishmentName} notifies me when new books arrival");
                library.registerObserver(this);
                isSubscribed = true;
            };
            Console.WriteLine();
            return;
        }

        Console.WriteLine($"Nice! I've got the {seekingBook} I was looking for\n");
        library.removeObserver(this);
    }

    public override void update()
    {
        lookForBook();
    }

    public String? bookLookingFor(){
        return borrowedBook == null ? seekingBook : null;
    }
}