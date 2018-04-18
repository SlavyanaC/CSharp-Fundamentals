public class Hard : Mission
{
    private const string HardMissionName = "Disposal of terrorists";
    private const double HardEnduranceReqired = 80;
    private const double HardWearLevelDecrement = 70;

    public Hard(double scoreToComplete) 
        : base(scoreToComplete)
    {
        this.Name = HardMissionName;
        this.EnduranceRequired = HardEnduranceReqired;
        this.WearLevelDecrement = HardWearLevelDecrement;
    }

    public override string Name { get; }

    public override double EnduranceRequired { get; }

    public override double WearLevelDecrement { get; }
}
