using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class ProviderControllerTests
{
    private IEnergyRepository energyRepository;
    private IProviderController providerController;
    private IProviderFactory factory;

    //{type} {id} {energyOutput}
    private List<string> firstTestProviderArgs = new List<string>() { "Standart", "1", "400", };
    private List<string> secondTestProviderArgs = new List<string>() { "Solar", "2", "400", };
    private List<string> thirdTestProviderArgs = new List<string>() { "Pressure", "3", "50", };

    private IProvider firstProvider;
    private IProvider secondProvider;
    private IProvider thirdProvider;

    [SetUp]
    public void SetUp()
    {
        this.energyRepository = new EnergyRepository();
        this.providerController = new ProviderController(this.energyRepository);
        this.factory = new ProviderFactory();

        this.firstProvider = this.factory.GenerateProvider(this.firstTestProviderArgs);
        this.secondProvider = this.factory.GenerateProvider(this.secondTestProviderArgs);
        this.thirdProvider = this.factory.GenerateProvider(this.thirdTestProviderArgs);
    }

    [Test]
    public void RegistrationReturnsCorrectMessageForAllTypesOfProviders()
    {
        string firstTestProviderResult = this.providerController.Register(this.firstTestProviderArgs);
        string secondTestProviderResult = this.providerController.Register(this.secondTestProviderArgs);
        string thirdTestProviderResult = this.providerController.Register(this.thirdTestProviderArgs);

        Assert.That(firstTestProviderResult, Is.EqualTo(string.Format(Constants.SuccessfullRegistration, firstProvider.GetType().Name)));
        Assert.That(secondTestProviderResult, Is.EqualTo(string.Format(Constants.SuccessfullRegistration, secondProvider.GetType().Name)));
        Assert.That(thirdTestProviderResult, Is.EqualTo(string.Format(Constants.SuccessfullRegistration, thirdProvider.GetType().Name)));
    }

    [Test]
    public void RegistrationAddsElementsToListOfProviders()
    {
        string firstTestProviderResult = this.providerController.Register(this.firstTestProviderArgs);
        string secondTestProviderResult = this.providerController.Register(this.secondTestProviderArgs);
        string thirdTestProviderResult = this.providerController.Register(this.thirdTestProviderArgs);

        IReadOnlyCollection<IEntity> providers = this.GetProviders();

        Assert.That(providers.Count, Is.EqualTo(3));
    }

    [Test]
    public void ProduceRemovesDeadProviders()
    {
        this.providerController.Register(this.firstTestProviderArgs);
        this.providerController.Register(this.secondTestProviderArgs);
        this.providerController.Register(this.thirdTestProviderArgs);

        for (int i = 0; i < 10; i++)
        {
            this.providerController.Produce();
        }

        IReadOnlyCollection<IEntity> providers = this.GetProviders();

        Assert.That(providers.Count, Is.EqualTo(2));
    }

    [Test]
    public void RepairProviders()
    {
        this.providerController.Register(this.firstTestProviderArgs);

        IReadOnlyCollection<IEntity> providers = GetProviders();
        double initialDurability = providers.First().Durability;

        double value = 20;
        this.providerController.Repair(value);

        double expexted = initialDurability + value;

        Assert.That(expexted, Is.EqualTo(initialDurability + value));
    }

    private IReadOnlyCollection<IEntity> GetProviders()
    {
        PropertyInfo providerEntities = this.providerController.GetType()
           .GetProperties()
           .FirstOrDefault(p => p.Name.Equals("Entities", StringComparison.OrdinalIgnoreCase));

        IReadOnlyCollection<IEntity> providers = (IReadOnlyCollection<IEntity>)providerEntities.GetValue(this.providerController);

        return providers;
    }
}

