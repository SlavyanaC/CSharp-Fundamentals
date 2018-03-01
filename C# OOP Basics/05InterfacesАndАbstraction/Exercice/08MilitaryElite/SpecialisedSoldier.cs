using System.Linq;

public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    private string[] validCorpses = { "Airforces", "Marines" };
    private string corps;

    public SpecialisedSoldier(int id, string firstName, string lastName, double salary, string corps)
        : base(id, firstName, lastName, salary)
    {
        this.Corps = corps;
    }

    public string Corps
    {
        get { return this.corps; }
        set
        {
            if (validCorpses.Contains(value))
            {
                this.corps = value;
            }
        }
    }
}
