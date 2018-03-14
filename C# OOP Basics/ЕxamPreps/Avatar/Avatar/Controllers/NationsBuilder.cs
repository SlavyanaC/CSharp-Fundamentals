using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBuilder
{
    private Dictionary<string, Nation> nations = new Dictionary<string, Nation>()
    {
        { "Air", new Nation() },
        { "Earth", new Nation() },
        { "Fire", new Nation() },
        { "Water", new Nation() },
    };

    private List<string> warsRecord = new List<string>();

    public void AssignBender(List<string> benderArgs)
    {
        var benderType = benderArgs[0];
        var bender = BenderFactory.Create(benderArgs);
        nations[benderType].AddBender(bender);
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        var monumentType = monumentArgs[0];
        var monument = MonumentFactory.Create(monumentArgs);
        nations[monumentType].AddMonument(monument);
    }

    public string GetStatus(string nationsType)
    {
        Nation nation = nations.FirstOrDefault(n => n.Key == nationsType).Value;
        var builder = new StringBuilder();
        builder.AppendLine($"{nationsType} Nation");
        builder.AppendLine(nation.ToString());

        return builder.ToString().TrimEnd();
    }

    public void IssueWar(string nationsType)
    {
        var bestTotalPower = nations.Max(kvp => kvp.Value.GetTotalPower());
        foreach (var nation in nations.Values)
        {
            if (nation.GetTotalPower() != bestTotalPower)
            {
                nation.DeclareDefeat();
            }
        }

        warsRecord.Add(nationsType);
    }

    public string GetWarsRecord()
    {
        var builder = new StringBuilder();
        for (int warNum = 0; warNum < warsRecord.Count; warNum++)
        {
            builder.AppendLine($"War {warNum + 1} issued by {warsRecord[warNum]}");
        }

        return builder.ToString().TrimEnd();
    }
}
