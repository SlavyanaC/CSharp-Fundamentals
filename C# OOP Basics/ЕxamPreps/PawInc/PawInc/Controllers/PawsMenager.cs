using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PawsMenager
{
    private List<Centre> centres;
    private List<Animal> adoptedAnimals;
    private List<Animal> cleansedAnimals;
    private List<Animal> castratedAnimals;

    private AnimalFactory animalFactory;
    private CentreFactory centreFactory;

    public PawsMenager()
    {
        this.centres = new List<Centre>();
        this.adoptedAnimals = new List<Animal>();
        this.cleansedAnimals = new List<Animal>();
        this.castratedAnimals = new List<Animal>();
        this.animalFactory = new AnimalFactory();
        this.centreFactory = new CentreFactory();
    }

    public void RegisterCleansingCenter(List<string> args)
    {
        CleansingCenter cleansingCenter = (CleansingCenter)this.centreFactory
            .Create("cleansing", args[0]);
        this.centres.Add(cleansingCenter);
    }

    public void RegisterAdoptionCenter(List<string> args)
    {
        AdoptionCenter adoptionCenter = (AdoptionCenter)this.centreFactory
            .Create("adoption", args[0]);
        this.centres.Add(adoptionCenter);
    }

    public void RegisterCastrationCenter(List<string> args)
    {
        CastrationCenter castrationCenter = (CastrationCenter)this.centreFactory
            .Create("castration", args[0]);
        this.centres.Add(castrationCenter);
    }

    public void RegisterDog(List<string> args)
    {
        var type = "dog";
        var centreName = args[3];
        var addoptionCentre = centres.FirstOrDefault(c => c.Name == centreName);
        Dog dog = (Dog)this.animalFactory.Create(type, args);
        addoptionCentre.StroredAnimals.Add(dog, centreName);
    }

    public void RegisterCat(List<string> args)
    {
        var type = "cat";
        var centreName = args[3];
        var adoptionCentre = this.centres.FirstOrDefault(c => c.Name == centreName);
        Cat cat = (Cat)this.animalFactory.Create(type, args);
        adoptionCentre.StroredAnimals.Add(cat, centreName);
    }

    public void SendForCleansing(List<string> args)
    {
        var adoptionCenterName = args[0];
        var cleansingCenterName = args[1];

        AdoptionCenter adoptionCentre = (AdoptionCenter)centres.FirstOrDefault(c => c.Name == adoptionCenterName);
        CleansingCenter cleansingCenter = (CleansingCenter)centres.FirstOrDefault(c => c.Name == cleansingCenterName);
        foreach (var animal in adoptionCentre.StroredAnimals)
        {
            cleansingCenter.StroredAnimals.Add(animal.Key, adoptionCentre.Name);
        }

        adoptionCentre.StroredAnimals.Clear();
    }

    public void SendForCastration(List<string> args)
    {
        var adoptionCenterName = args[0];
        var castrationCenterName = args[1];

        AdoptionCenter adoptionCentre = (AdoptionCenter)centres.FirstOrDefault(c => c.Name == adoptionCenterName);
        CastrationCenter castrationCenter = (CastrationCenter)centres.FirstOrDefault(c => c.Name == castrationCenterName);
        foreach (var animal in adoptionCentre.StroredAnimals)
        {
            castrationCenter.StroredAnimals.Add(animal.Key, adoptionCentre.Name);
        }

        adoptionCentre.StroredAnimals.Clear();
    }

    public void Cleanse(List<string> args)
    {
        var cleansingCenterName = args[0];
        CleansingCenter cleansingCentre = (CleansingCenter)centres.FirstOrDefault(c => c.Name == cleansingCenterName);

        foreach (var animal in cleansingCentre.StroredAnimals)
        {
            animal.Key.Cleanse();
            this.cleansedAnimals.Add(animal.Key);

            var adoptionCentreName = animal.Value;
            AdoptionCenter adoptionCenter = (AdoptionCenter)centres.FirstOrDefault(c => c.Name == adoptionCentreName);
            adoptionCenter.StroredAnimals.Add(animal.Key, adoptionCentreName);
        }

        cleansingCentre.StroredAnimals.Clear();
    }

    public void Castrate(List<string> args)
    {
        var castrationCentreName = args[0];
        CastrationCenter castrationCentre = (CastrationCenter)centres.FirstOrDefault(c => c.Name == castrationCentreName);

        foreach (var animal in castrationCentre.StroredAnimals)
        {
            animal.Key.Castrate();
            this.castratedAnimals.Add(animal.Key);

            var adoptionCentreName = animal.Value;
            AdoptionCenter adoptionCenter = (AdoptionCenter)centres.FirstOrDefault(c => c.Name == adoptionCentreName);
            adoptionCenter.StroredAnimals.Add(animal.Key, adoptionCentreName);
        }

        castrationCentre.StroredAnimals.Clear();
    }

    public void Adopt(List<string> args)
    {
        var adoptionCentreName = args[0];
        AdoptionCenter adoptionCentre = (AdoptionCenter)centres.FirstOrDefault(c => c.Name == adoptionCentreName);

        var copy = new Dictionary<Animal, string>(adoptionCentre.StroredAnimals);
        foreach (var animal in copy.Keys)
        {
            if (animal.CleansingStatus)
            {
                this.adoptedAnimals.Add(animal);
                adoptionCentre.StroredAnimals.Remove(animal);
            }
        }
    }


    public string CastrationStatistics()
    {
        var castrationCentresCount = 0;
        foreach (var centre in centres)
        {
            if (centre is CastrationCenter)
                castrationCentresCount++;
        }

        var castratedAnimals = this.castratedAnimals.Count == 0 ? "None" : string.Join(", ", this.castratedAnimals.OrderBy(a => a.Name).Select(a => a.Name));

        var builder = new StringBuilder();
        builder.AppendLine("Paw Inc. Regular Castration Statistics");
        builder.AppendLine($"Castration Centers: {castrationCentresCount}");
        builder.AppendLine($"Castrated Animals: {castratedAnimals}");

        return builder.ToString().TrimEnd();
    }

    public string Output()
    {
        var adoptinCentresCount = 0;
        var cleansingCentresCount = 0;
        foreach (var centre in centres)
        {
            if (centre is AdoptionCenter)
                adoptinCentresCount++;
            if (centre is CleansingCenter)
                cleansingCentresCount++;
        }

        var awaitingAdoption = 0;
        var awaitingCleansing = 0;
        foreach (var centre in centres)
        {
            foreach (var animal in centre.StroredAnimals)
            {
                if (animal.Key.CleansingStatus)
                {
                    awaitingAdoption++;
                }
                if (!animal.Key.CleansingStatus && centre is CleansingCenter)
                {
                    awaitingCleansing++;
                }
            }
        }

        var adoptedAnimals = this.adoptedAnimals.Count == 0 ? "None" : string.Join(", ", this.adoptedAnimals.OrderBy(a => a.Name).Select(a => a.Name));
        var cleansedAnimals = this.cleansedAnimals.Count == 0 ? "None" : string.Join(", ", this.cleansedAnimals.OrderBy(a => a.Name).Select(a => a.Name));

        var builder = new StringBuilder();
        builder.AppendLine("Paw Incorporative Regular Statistics");
        builder.AppendLine($"Adoption Centers: {adoptinCentresCount}");
        builder.AppendLine($"Cleansing Centers: {cleansingCentresCount}");
        builder.AppendLine($"Adopted Animals: {adoptedAnimals}");
        builder.AppendLine($"Cleansed Animals: {cleansedAnimals}");
        builder.AppendLine($"Animals Awaiting Adoption: {awaitingAdoption}");
        builder.AppendLine($"Animals Awaiting Cleansing: {awaitingCleansing}");

        return builder.ToString().TrimEnd();
    }
}