public interface IHarvesterController : IController
{
    double ОreOutput { get; }

    string ChangeMode(string mode);
}