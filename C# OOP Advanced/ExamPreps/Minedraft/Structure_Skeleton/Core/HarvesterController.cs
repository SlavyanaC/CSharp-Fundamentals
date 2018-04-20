using System;
using System.Collections.Generic;
using System.Linq;

public class HarvesterController : IHarvesterController
{
    private const double FullEnergyRequirement = 100.00;
    private const double HalfEnergyRequirement = 50.00;
    private const double EnergyEnergyRequirement = 20.00;
    private const double MinDurability = 0;

    private IHarvesterFactory harvesterFactory;
    private readonly IList<IHarvester> harvesters;
    private IEnergyRepository energyRepository;

    private string mode;

    public HarvesterController(IHarvesterFactory harvesterFactory, IList<IHarvester> harvesters, IEnergyRepository energyRepository)
    {
        this.harvesterFactory = harvesterFactory;
        this.harvesters = new List<IHarvester>();
        this.energyRepository = energyRepository;
        this.ОreOutput = 0;
        this.mode = "Full";
    }

    public double ОreOutput { get; private set; }

    public IReadOnlyCollection<IEntity> Entities => (IReadOnlyCollection<IHarvester>)this.harvesters;

    public string Register(IList<string> args)
    {
        IHarvester harvester = this.harvesterFactory.GenerateHarvester(args);
        harvesters.Add(harvester);
        return string.Format(Constants.SuccessfullRegistration, harvester.GetType().Name);
    }

    public string ChangeMode(string mode)
    {
        if (mode.Equals("Full") || mode.Equals("Half") || mode.Equals("Energy"))
        {
            this.mode = mode;
        }

        List<IHarvester> reminder = new List<IHarvester>();
        foreach (IHarvester harvester in this.harvesters)
        {
            try
            {
                harvester.Broke();
            }
            catch(Exception)
            {
                reminder.Add(harvester);
            }
        }

        foreach (var entity in reminder)
        {
            this.harvesters.Remove(entity);
        }

        return string.Format(Constants.ModeChange, mode);
    }

    public string Produce()
    {
        double energyNeeded = 0;
        foreach (IHarvester harvester in this.harvesters)
        {
            if (this.mode.Equals("Full"))
            {
                energyNeeded += harvester.EnergyRequirement * FullEnergyRequirement / 100;
            }
            if (this.mode.Equals("Half"))
            {
                energyNeeded += harvester.EnergyRequirement * HalfEnergyRequirement / 100;
            }
            if (this.mode.Equals("Energy"))
            {
                energyNeeded += harvester.EnergyRequirement * EnergyEnergyRequirement / 100;
            }
        }

        double oreOutput = 0;
        if (this.energyRepository.EnergyStored >= energyNeeded)
        {
            this.energyRepository.TakeEnergy(energyNeeded);

            foreach (IHarvester harvester in this.harvesters)
            {
                oreOutput += harvester.Produce();
            }

            if (this.mode == "Energy")
            {
                oreOutput *= EnergyEnergyRequirement / 100;
            }
            else if (this.mode == "Half")
            {
                oreOutput *= HalfEnergyRequirement / 100;
            }

            this.ОreOutput += oreOutput;
        }

        return string.Format(Constants.OreOutputToday, oreOutput);
    }
}
