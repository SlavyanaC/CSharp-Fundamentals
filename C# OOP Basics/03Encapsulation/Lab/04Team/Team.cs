using System;
using System.Collections.Generic;
using System.Text;

public class Team
{
    private string name;
    private List<Person> firstTeam;
    private List<Person> reserveTeam;

    public Team(string name)
    {
        this.Name = name;
        this.firstTeam = new List<Person>();
        this.reserveTeam = new List<Person>();
    }   

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public IReadOnlyCollection<Person> FirstTeam
    {
        get { return firstTeam; }
    }

    public IReadOnlyCollection<Person> ReserveTeam
    {
        get { return reserveTeam; }
    }

    public void AddPerson(Person person)
    {
        if (person.Age < 40)
        {
            firstTeam.Add(person);
        }
        else
        {
            reserveTeam.Add(person);    
        }
    }
}
