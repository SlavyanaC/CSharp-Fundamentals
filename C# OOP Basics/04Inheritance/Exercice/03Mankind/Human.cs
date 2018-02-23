using System;
using System.Linq;

public class Human
{
    private string firstName;
    private string lastName;

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public string FirstName
    {
        get { return firstName; }
        set
        {
            if (value?.Length < 4)
            {
                throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
            }
            else if (char.IsLower(value.First()))
            {
                throw new ArgumentException("Expected upper case letter! Argument: firstName");
            }
            firstName = value;
        }
    }

    public string LastName
    {
        get { return lastName; }
        set
        {
            if (value?.Length < 3)
            {
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
            }
            else if (char.IsLower(value.First()))
            {
                throw new ArgumentException("Expected upper case letter! Argument: lastName");
            }
            lastName = value;
        }
    }
}
