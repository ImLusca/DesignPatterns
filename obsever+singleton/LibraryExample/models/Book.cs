namespace design.LibraryExample.implementation;

public class Book : IProduct
{
    public String name { get; }
    public String author { get; }
    public int year { get; }

    public Book(String _name, String _author, int _year)
    {
        name = _name;
        author = _author;
        year = _year;
    }
}