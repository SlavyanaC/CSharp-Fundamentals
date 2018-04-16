using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class InspectCommand : Command
{
    public InspectCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments, harvesterController, providerController)
    {
    }

    public override string Execute()
    {
        int id = int.Parse(this.Arguments.First());
        List<IEntity> entities = new List<IEntity>();
        GetHarvesters(entities);
        GetProviders(entities);

        IEntity wantedEntity = entities.FirstOrDefault(e => e.ID.Equals(id));
        if (wantedEntity == null)
        {
            return string.Format(Constants.NoEntityFound, id);
        }

        string result = string.Format(Constants.EntityFound, wantedEntity.GetType().Name, wantedEntity.Durability);
        return result;
    }

    private void GetProviders(List<IEntity> entities)
    {
        var providerEntities = this.ProviderController
            .GetType()
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(f => f.Name.Equals("providers"))
            .GetValue(this.ProviderController);

        entities.AddRange((List<IProvider>)providerEntities);
    }

    private void GetHarvesters(List<IEntity> entities)
    {
        var harvesterEntities = this.HarvesterController
            .GetType()
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(f => f.Name.Equals("harvesters"))
            .GetValue(this.HarvesterController); 

        entities.AddRange((List<IHarvester>)harvesterEntities);
    }
}
