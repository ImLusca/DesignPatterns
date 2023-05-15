namespace design.sayHello.models;

public class PersonAgeDecorator : Person
{
    private int age { get; set; }
    Person componente { get; set; }
    public PersonAgeDecorator(Person _componente, int _age)
    {
        age = _age;
        componente = _componente;
    }

    public override string sayHello()
    {
        return $"{componente.sayHello()}, I'm {age} years old";
    }
}