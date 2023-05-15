namespace design.sayHello.models;

public class PersonColorDecorator : Person
{
    private string favoriteColor { get; set; }
    Person componente { get; set; }
    public PersonColorDecorator(Person _componente, string _favoriteColor)
    {
        favoriteColor = _favoriteColor;
        componente = _componente;
    }

    public override string sayHello()
    {
        return $"{componente.sayHello()}, my favorite color is {favoriteColor}";
    }
}