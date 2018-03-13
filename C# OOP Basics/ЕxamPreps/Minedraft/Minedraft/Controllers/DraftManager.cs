using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private ICollection<Harvester> harvesters = new List<Harvester>();
    private ICollection<Provider> providers = new List<Provider>();

    private string mode = "Full";
    private double totalStoredEnergy;
    private double totalMinedOre;

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            var harvester = HarvesterFactory.CreateHarvester(arguments);
            harvesters.Add(harvester);
            return $"Successfully registered {harvester.Name} Harvester - {harvester.Id}";
        }
        catch (ArgumentException exception)
        {
            return exception.Message;
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            var provider = ProviderFactory.CreateProvider(arguments);
            providers.Add(provider);
            return $"Successfully registered {provider.Name} Provider - {provider.Id}";
        }
        catch (ArgumentException exception)
        {
            return exception.Message;
        }
    }

    public string Day()
    {
        double dailyProvidedEnergy = this.providers.Sum(p => p.EnergyOutput);
        this.totalStoredEnergy += dailyProvidedEnergy;
        double requiredEnergyPerMode = 0;
        double minedOrePerMode = 0;
        double dailyMinedOre = 0;
    
        if (this.mode != "Energy")
        {
            switch (this.mode)
            {
                case "Full":
                    requiredEnergyPerMode = this.harvesters.Sum(h => h.EnergyRequirement);
                    minedOrePerMode = this.harvesters.Sum(h => h.OreOutput);
                    break;
                case "Half":
                    requiredEnergyPerMode = this.harvesters.Sum(h => h.EnergyRequirement * 0.6);
                    minedOrePerMode = this.harvesters.Sum(h => h.OreOutput * 0.5);
                    break;
            }

            if (requiredEnergyPerMode <= this.totalStoredEnergy)
            {
                this.totalStoredEnergy -= requiredEnergyPerMode;
                dailyMinedOre += minedOrePerMode;
                this.totalMinedOre += dailyMinedOre;
            }
        }

        StringBuilder builder = new StringBuilder();
        builder.AppendLine("A day has passed.");
        builder.AppendLine($"Energy Provided: {dailyProvidedEnergy}");
        builder.AppendLine($"Plumbus Ore Mined: {dailyMinedOre}");

        return builder.ToString().TrimEnd();
    }

    public string Mode(List<string> arguments)
    {
        this.mode = arguments[0];
        return $"Successfully changed working mode to {mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        var id = arguments[0];

        var harvester = harvesters.FirstOrDefault(h => h.Id == id);
        if (harvester != null)
        {
            return harvester.ToString();
        }


        var provider = providers.FirstOrDefault(p => p.Id == id);
        if (provider != null)
        {
            return provider.ToString();
        }

        return $"No element found with id - {id}";
    }

    public string ShutDown()
    {
        var builder = new StringBuilder();
        builder.AppendLine("System Shutdown");
        builder.AppendLine($"Total Energy Stored: {(int)totalStoredEnergy}");
        builder.AppendLine($"Total Mined Plumbus Ore: {(int)totalMinedOre}");

        return builder.ToString().TrimEnd();
    }
}
