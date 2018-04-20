using NUnit.Framework;
using System.Collections.Generic;

public class ProviderControllerTests
{
    private IEnergyRepository energyRepository;
    private IProviderController providerController;

    [SetUp]
    public void SetUp()
    {
        this.energyRepository = new EnergyRepository();
        this.providerController = new ProviderController(this.energyRepository);
    }

    [Test]
    public void ProduceCorrectAmountOfEnergy()
    {
        List<string> firstProvider = new List<string>()
        {
           "Solar", "1", "100"
        };
        List<string> SecondProvider = new List<string>()
        {
           "Solar", "2", "100"
        };

        this.providerController.Register(firstProvider);
        this.providerController.Register(SecondProvider);

        for (int i = 0; i < 3; i++)
        {
            this.providerController.Produce();
        }

        Assert.That(this.providerController.TotalEnergyProduced, Is.EqualTo(600));
    }

    [Test]
    public void BrokenProviderIsDeleted()
    {
        List<string> firstProvider = new List<string>()
        {
           "Pressure", "1", "100"
        };
        this.providerController.Register(firstProvider);
        for (int i = 0; i < 8; i++)
        {
            this.providerController.Produce();
        }

        Assert.That(this.providerController.Entities.Count, Is.EqualTo(0));
    }
}

