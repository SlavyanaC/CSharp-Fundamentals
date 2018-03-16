using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PawsMenager
{
    private Dictionary<Centre, List<Animal>> centres;
    private List<Animal> adoptedAnimals;
    private List<Animal> cleansedAnimals;
    private List<Animal> castratedAnimals;

    private AnimalFactory animalFactory;
    private CentreFactory centreFactory;

    public PawsMenager()
    {
        this.centres = new Dictionary<Centre, List<Animal>>();
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
        this.centres[cleansingCenter] = new List<Animal>();
    }

    public void RegisterAdoptionCenter(List<string> args)
    {
        AdoptionCenter adoptionCenter = (AdoptionCenter)this.centreFactory
            .Create("adoption", args[0]);
        this.centres[adoptionCenter] = new List<Animal>();
    }

    public void RegisterCastrationCenter(List<string> args)
    {
        CastrationCenter castrationCenter = (CastrationCenter)this.centreFactory
            .Create("castration", args[0]);
        this.centres[castrationCenter] = new List<Animal>();
    }

    public void RegisterDog(List<string> args)
    {
        var type = "dog";
        var centreName = args[3];
        var addoptionCentre = centres.FirstOrDefault(c => c.Key.Name == centreName).Key;
        Dog dog = (Dog)this.animalFactory.Create(type, args);
        this.centres[addoptionCentre].Add(dog);
    }

    public void RegisterCat(List<string> args)
    {
        var type = "cat";
        var centreName = args[3];
        var adoptionCentre = this.centres.FirstOrDefault(c => c.Key.Name == centreName).Key;
        Cat cat = (Cat)this.animalFactory.Create(type, args);
        this.centres[adoptionCentre].Add(cat);
    }

    public void SendForCleansing(List<string> args)
    {
        var adoptionCenterName = args[0];
        var cleansingCenterName = args[1];

        var adoptionCentre = centres.FirstOrDefault(c => c.Key.Name == adoptionCenterName);
        CleansingCenter cleansingCenter = (CleansingCenter)centres.FirstOrDefault(c => c.Key.Name == cleansingCenterName).Key;
        foreach (var animal in adoptionCentre.Value)
        {
            centres[cleansingCenter].Add(animal);
        }
    }

    public void SendForCastration(List<string> args)
    {
        var adoptionCenterName = args[0];
        var castrationCenterName = args[1];

        var adoptionCentre = centres.FirstOrDefault(c => c.Key.Name == adoptionCenterName);
        CastrationCenter castrationCenter = (CastrationCenter)centres.FirstOrDefault(c => c.Key.Name == castrationCenterName).Key;
        foreach (var animal in adoptionCentre.Value)
        {
            centres[castrationCenter].Add(animal);
        }
    }

    public void Cleanse(List<string> args)
    {
        var cleansingCenterName = args[0];
        var cleansingCentre = centres.FirstOrDefault(c => c.Key.Name == cleansingCenterName);

        foreach (var animal in cleansingCentre.Value)
        {
            animal.Cleanse();
            this.cleansedAnimals.Add(animal);
            foreach (var centre in centres)
            {
                if (centre.Value.Contains(animal) && centre.Key is AdoptionCenter)
                {
                    centre.Value.FirstOrDefault(a => a.Name == animal.Name).Cleanse();
                }
            }
        }

        centres[cleansingCentre.Key].Clear();
    }

    public void Castrate(List<string> args)
    {
        var castrationCentreName = args[0];
        var castrationCentre = centres.FirstOrDefault(c => c.Key.Name == castrationCentreName);

        foreach (var animal in castrationCentre.Value)
        {
            animal.Castrate();
            this.castratedAnimals.Add(animal);
            foreach (var centre in centres)
            {
                if (centre.Value.Contains(animal) && centre.Key is AdoptionCenter)
                {
                    centre.Value.FirstOrDefault(a => a.Name == animal.Name).Castrate();
                }
            }
        }

        centres[castrationCentre.Key].Clear();
    }

    public void Adopt(List<string> args)
    {
        var adoptionCentreName = args[0];
        var adoptionCentre = centres.FirstOrDefault(c => c.Key.Name == adoptionCentreName).Key;

        foreach (var centre in centres)
        {
            if (centre.Key.Equals(adoptionCentre))
            {
                for (int index = 0; index < centre.Value.Count; index++)
                {
                    if (centre.Value[index].CleansingStatus)
                    {
                        this.adoptedAnimals.Add(centre.Value[index]);
                        centre.Value.RemoveAt(index);
                        index--;
                    }
                }
            }
        }
    }


    public string CastrationStatistics()
    {
        var castrationCentresCount = 0;
        foreach (var centre in centres)
        {
            if (centre.Key is CastrationCenter)
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
            if (centre.Key is AdoptionCenter)
                adoptinCentresCount++;
            if (centre.Key is CleansingCenter)
                cleansingCentresCount++;
        }

        var awaitingAdoption = 0;
        var awaitingCleansing = 0;
        foreach (var centre in centres)
        {
            foreach (var animal in centre.Value)
            {
                if (animal.CleansingStatus && centre.Key is AdoptionCenter)
                {
                    awaitingAdoption++;
                }
                if (!animal.CleansingStatus && centre.Key is CleansingCenter)
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