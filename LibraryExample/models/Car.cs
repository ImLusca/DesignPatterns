namespace design.LibraryExample.implementation;

public class Car : IProduct
{
    public String name { get; }
    public String brand { get; }
    public int year { get; }

    public Car(String _name, String _brand, int _year)
    {
        name = _name;
        brand = _brand;
        year = _year;
    }
}