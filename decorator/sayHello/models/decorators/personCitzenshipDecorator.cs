namespace design.sayHello.models;

public class PersonCitzenshipDecorator : Person
{
    private string citzenship { get; set; }
    Person componente { get; set; }
    public PersonCitzenshipDecorator(Person _componente, string _citzenship)
    {
        citzenship = _citzenship;
        componente = _componente;
    }

    public override string sayHello()
    {
        return $"{componente.sayHello()}, I'm from {citzenship}";
    }
}