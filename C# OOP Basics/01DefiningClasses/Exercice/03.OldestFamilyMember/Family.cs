using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Family
{
    private List<Person> members;

    public Family()
    {
        this.members = new List<Person>();
    }

    public void AddMembers(Person member)
    {
        this.members.Add(member);
    }

    public Person GetOldestMember()
    {
        return this.members
            .OrderByDescending(m => m.Age)
            .FirstOrDefault();
    }
}
