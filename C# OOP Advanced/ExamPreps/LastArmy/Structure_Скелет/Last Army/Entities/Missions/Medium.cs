public class Medium : Mission
{
    private const string MediumMissionName = "Capturing dangerous criminals";
    private const double MediumEnduranceRequired = 50;
    private const double MediumWearLevelDecrement = 50;

    public Medium(double scoreToComplete) 
        : base(scoreToComplete)
    {
        this.Name = MediumMissionName;
        this.EnduranceRequired = MediumEnduranceRequired;
        this.WearLevelDecrement = MediumWearLevelDecrement;
    }

    public override string Name { get; }

    public override double EnduranceRequired { get;}

    public override double WearLevelDecrement { get; }
}
