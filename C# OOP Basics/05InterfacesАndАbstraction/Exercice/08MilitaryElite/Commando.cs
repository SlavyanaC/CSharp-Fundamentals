using System.Collections.Generic;
using System.Text;

public class Commando : SpecialisedSoldier, ICommando
{
    public Commando(int id, string firstName, string lastName, double salary, string corps)
        : base(id, firstName, lastName, salary, corps)
    {
        this.Missions = new List<IMission>();
    }

    public IList<IMission> Missions { get; private set; }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}");
        builder.AppendLine($"Corps: {this.Corps}");
        builder.AppendLine("Missions:");
        foreach (var mission in Missions)
        {
            builder.AppendLine(mission.ToString());
        }

        return builder.ToString().TrimEnd();
    }
}
