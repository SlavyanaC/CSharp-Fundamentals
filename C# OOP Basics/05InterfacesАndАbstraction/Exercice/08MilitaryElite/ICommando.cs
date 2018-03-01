using System.Collections.Generic;

public interface ICommando
{
    IList<IMission> Missions { get; }
}
