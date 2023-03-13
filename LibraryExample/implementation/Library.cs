namespace design.LibraryExample.implementation;

sealed class Library : Subject, IRenters
{
    private Library() { }
    private static Library? _instance;
    public static Library getInstance()
    {
        if (_instance == null) _instance = new Library();
        return _instance;
    }

    private Dictionary<String, Book> availableBooks = new Dictionary<string, Book>();

    public void addProducts(List<Book> books)
    {
        foreach (Book book in books)
        {
            availableBooks.Add(book.name, book);
        }
        notify();
    }

    public Book? borrowProduct(string bookName)
    {
        if (!isAvailable(bookName)) return null;

        Book book = availableBooks[bookName];
        reserveBook(book);
        return book;
    }

    private Boolean isAvailable(String bookName)
    {
        return availableBooks.ContainsKey(bookName);
    }

    private void reserveBook(Book book)
    {
        availableBooks.Remove(book.name);
    }

    public int countListningObservers()
    {
        return observers.Count;
    }

    public string establishementName { get; } = "Library";
    public string product { get; } = "Book";

}