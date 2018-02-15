using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Person
{
    private string name;
    private Car car;
    private Company company;
    private List<Pokemon> pokemons;
    private List<Parent> parents;
    private List<Child> children;

    public Person(string name)
    {
        this.name = name;
        this.company = new Company();
        this.car = new Car();
        this.pokemons = new List<Pokemon>();
        this.parents = new List<Parent>();
        this.children = new List<Child>();
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Company Company
    {
        get { return company; }
        set { company = value; }
    }

    public Car Car
    {
        get { return car; }
        set { car = value; }
    }

    public List<Pokemon> Pokemons
    {
        get { return pokemons; }
        set { pokemons = value; }
    }

    public List<Parent> Parents
    {
        get { return parents; }
        set { parents = value; }
    }

    public List<Child> Children
    {
        get { return children; }
        set { children = value; }
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder().AppendLine(this.name);

        builder.AppendLine("Company:");
        if (this.company.Name != string.Empty)
        {
            builder.AppendLine(this.company.ToString());
        }

        builder.AppendLine("Car:");
        if (this.car.Model != string.Empty)
        {
            builder.AppendLine(this.car.ToString());
        }

        builder.AppendLine("Pokemon:");
        this.pokemons.ForEach(p => builder.AppendLine(p.ToString()));

        builder.AppendLine("Parents:");
        this.parents.ForEach(p => builder.AppendLine(p.ToString()));

        builder.AppendLine("Children:");
        this.children.ForEach(c => builder.AppendLine(c.ToString()));

        return builder.ToString();
    }
}
