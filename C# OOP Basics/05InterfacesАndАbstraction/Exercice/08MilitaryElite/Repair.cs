public class Repair : IRepair
{
    public Repair(string partName, int hours)
    {
        this.PartName = partName;
        this.Hours = hours;
    }

    public string PartName { get; private set; }

    public int Hours { get; private set; }

    public override string ToString()
    {
        string output = $"Part Name: {this.PartName} Hours Worked: {this.Hours}";
        return output;
    }
}
