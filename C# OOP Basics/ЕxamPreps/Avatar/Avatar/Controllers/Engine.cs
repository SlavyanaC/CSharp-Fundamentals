using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Engine
{
    private NationsBuilder nationsBuilder = new NationsBuilder();

    public void Run()
    {
        while (true)
        {
            var input = Console.ReadLine();
            var args = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var command = args[0];
            args = args.Skip(1).ToList();

            switch (command)
            {
                case "Bender":
                    this.nationsBuilder.AssignBender(args);
                    break;
                case "Monument":
                    this.nationsBuilder.AssignMonument(args);
                    break;
                case "Status":
                    Console.WriteLine(this.nationsBuilder.GetStatus(args[0]));
                    break;
                case "War":
                    this.nationsBuilder.IssueWar(args[0]);
                    break;
                case "Quit":
                    Console.WriteLine(this.nationsBuilder.GetWarsRecord());
                    return;
                default:
                    break;
            }
        }
    }
}
