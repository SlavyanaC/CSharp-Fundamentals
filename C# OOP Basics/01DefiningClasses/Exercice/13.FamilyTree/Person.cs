using System.Collections.Generic;
using System.Linq;

public class Person
{
    private List<Person> children;

    public Person()
    {
        this.children = new List<Person>();
    }

    public Person(string name, string birthdate) : this()
    {
        this.Name = name;
        this.Birthday = birthdate;
    }

    public string Name { get; set; }
    public string Birthday { get; set; }

    public List<Person> Children => this.children;

    public void AddChild(Person child)
    {
        this.children.Add(child);
    }

    public void AddChildInfo(string name, string birthday)
    {
        if (this.children.FirstOrDefault(c => c.Name == name) != null)
        {
            this.children
                .FirstOrDefault(c => c.Name == name)
                .Birthday = birthday;
            return;
        }
        if (this.children.FirstOrDefault(c => c.Birthday == birthday) != null)
        {
            this.children
                .FirstOrDefault(c => c.Birthday == birthday)
                .Name = name;
        }
    }

    public Person FindChild(string childName)
    {
        return this.children.FirstOrDefault(c => c.Name == childName);
    }
}