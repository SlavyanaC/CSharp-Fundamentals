using System.Collections.Generic;

public interface IHarvesterController : IController
{
    double ОreOutput { get; }

    string ChangeMode(string mode);

    IReadOnlyCollection<IEntity> Entities { get; }
}