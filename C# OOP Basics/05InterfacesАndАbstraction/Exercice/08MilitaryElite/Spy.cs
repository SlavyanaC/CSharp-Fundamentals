using System.Text;

public class Spy : Soldier, ISpy
{
    public Spy(int id, string firstName, string lastName, int codeNumber)
        : base(id, firstName, lastName)
    {
        this.CodeNumber = codeNumber;
    }

    public int CodeNumber { get; private set; }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id}");
        builder.AppendLine($"Code Number: {this.CodeNumber}");
        return builder.ToString().TrimEnd();
    }
}
