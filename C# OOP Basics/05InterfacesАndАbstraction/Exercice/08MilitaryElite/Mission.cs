public class Mission : IMission
{
    public Mission(string codeName, string state)
    {
        this.CodeName = codeName;
        this.State = state;
    }

    public string CodeName { get; private set; }

    public string State { get; private set; }

    public void CompleteMission()
    {
        this.State = "Finished";
    }

    public override string ToString()
    {
        var output = $"Code Name: {this.CodeName} State: {this.State}";
        return output;
    }
}
