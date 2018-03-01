using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    public Engineer(int id, string firstName, string lastName, double salary, string corps)
        : base(id, firstName, lastName, salary, corps)
    {
        this.Repairs = new List<IRepair>();
    }

    public IList<IRepair> Repairs { get; private set; }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}");
        builder.AppendLine($"Corps: {this.Corps}");
        builder.AppendLine("Repairs:");
        foreach (var repair in Repairs)
        {
            builder.AppendLine($"   {repair.ToString()}");
        }

        return builder.ToString().TrimEnd();
    }
}
