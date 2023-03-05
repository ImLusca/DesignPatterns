namespace design.LibraryExample.implementation;

public class Customer : IObserver
{

    private Book? borrowedBook;
    private String seekingBook;

    public Customer(String bookName)
    {
        seekingBook = bookName;
    }

    public void lookForBook()
    {
        var library = Library.getInstance();

        borrowedBook = library.borrowBook(seekingBook);

        if (borrowedBook == null)
        {
            Console.WriteLine($"I didn't got the {seekingBook} I'm looking for");
            if (!isSubscribed)
            {
                Console.WriteLine("I will ask to the library notifies me when new books arrival");
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