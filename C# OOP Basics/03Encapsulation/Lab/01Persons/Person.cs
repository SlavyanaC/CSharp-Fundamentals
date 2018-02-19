using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private string firstName;
    private string lastName;
    private int age;

    public Person(string firstName, string lastName, int age)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

    public string FirstName
    {
        get { return firstName; }
    }

    public string LastName
    {
        get { return lastName; }
    }

    public int Age
    {
        get { return age; }
    }

    public override string ToString()
    {
        return $"{this.firstName} {this.lastName} is {this.age} years old.";
    }
}
