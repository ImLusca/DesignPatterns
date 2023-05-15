namespace design.sayHello;

using System;
using models.Persons;
using models;

public class Main
{
    public static void main()
    {
        Person brazilianJoao = new PersonCitzenshipDecorator(new Joao(), "Brazil");

        Console.WriteLine(brazilianJoao.sayHello());

        Person brazilianJoaoWithAge = new PersonAgeDecorator(brazilianJoao, 20);

        Console.WriteLine(brazilianJoaoWithAge.sayHello());

        Person Julia = new Julia();

        Console.WriteLine(Julia.sayHello());

        Console.WriteLine(new PersonColorDecorator(Julia, "Black").sayHello());

        Console.WriteLine(new PersonAgeDecorator(new PersonColorDecorator(new PersonCitzenshipDecorator(new Pedro(), "China"), "White"), 29).sayHello());


        Console.WriteLine(Julia.sayHello());

    }
}