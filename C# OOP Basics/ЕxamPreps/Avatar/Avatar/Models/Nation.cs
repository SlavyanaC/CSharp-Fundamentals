using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Nation
{
    private List<Bender> benders = new List<Bender>();
    private List<Monument> monuments = new List<Monument>();

    public double GetTotalPower()
    {
        double bendersPower = this.benders.Sum(b => b.GetPower());
        int monumentAffinity = this.monuments.Sum(m => m.GetAffinity());
        var totalPower = (bendersPower / 100) * monumentAffinity;

        return totalPower;
    }

    public void AddBender(Bender bender)
    {
        this.benders.Add(bender);
    }

    public void AddMonument(Monument monument)
    {
        this.monuments.Add(monument);
    }

    public void DeclareDefeat()
    {
        this.benders.Clear();
        this.monuments.Clear();
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        if (benders.Count < 1)
        {
            builder.AppendLine($"Benders: None");
        }
        else
        {
            builder.AppendLine($"Benders:");
            foreach (var bender in benders)
            {
                builder.AppendLine(bender.ToString());
            }
        }

        if (monuments.Count < 1)
        {
            builder.AppendLine($"Monuments: None");
        }
        else
        {
            builder.AppendLine($"Monuments:");
            foreach (var monument in monuments)
            {
                builder.AppendLine(monument.ToString());
            }
        }

        return builder.ToString().TrimEnd();
    }
}
