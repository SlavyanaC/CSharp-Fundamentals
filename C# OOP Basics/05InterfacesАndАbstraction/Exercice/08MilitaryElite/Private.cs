using System.Text;

public class Private : Soldier, IPrivate
{
    public Private(int id, string firstName, string lastName, double salary)
        : base(id, firstName, lastName)
    {
        this.Salary = salary;
    }

    public double Salary { get; private set; }

    public override string ToString()
    {
        string output = $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}";
        return output;
    }
}
