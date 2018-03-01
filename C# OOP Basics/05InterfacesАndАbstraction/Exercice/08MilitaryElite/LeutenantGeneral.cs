using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Private, IPrivate, ILeutenantGeneral
{
    public LeutenantGeneral(int id, string firstName, string lastName, double salary)
        : base(id, firstName, lastName, salary)
    {
        this.Privates = new List<Private>();
    }

    public List<Private> Privates { get; private set; }

    public void AddPrivate(Private @private)
    {
        this.Privates.Add(@private);
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}");
        builder.AppendLine("Privates:");
        foreach (var @private in this.Privates)
        {
            builder.AppendLine($"   {@private.ToString()}");
        }
        return builder.ToString().TrimEnd();
    }
}
