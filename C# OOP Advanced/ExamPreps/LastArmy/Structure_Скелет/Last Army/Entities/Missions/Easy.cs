public class Easy : Mission
{
    private const string EasyMissionName = "Suppression of civil rebellion";
    private const double EasyEnduranceRequired = 20;
    private const double EasyWeaeLevelDecrement = 30;

    public Easy(double scoreToComplete) 
        : base(scoreToComplete)
    {
        this.Name = EasyMissionName;
        this.EnduranceRequired = EasyEnduranceRequired;
        this.WearLevelDecrement = EasyWeaeLevelDecrement;
    }

    public override string Name { get; }

    public override double EnduranceRequired { get; }

    public override double WearLevelDecrement { get;  }
}
