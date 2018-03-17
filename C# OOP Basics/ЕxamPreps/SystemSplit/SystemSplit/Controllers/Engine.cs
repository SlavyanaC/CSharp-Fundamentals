using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Engine
{
    private SystemMenager systemMenager;

    public Engine()
    {
        this.systemMenager = new SystemMenager();
    }

    public void Run()
    {
        var input = Console.ReadLine();
        while (true)
        {
            var args = input
                .Split(new[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            var command = args[0];
            args = args.Skip(1).ToList();
            switch (command)
            {
                case "RegisterPowerHardware":
                    this.systemMenager.RegisterPowerHardware(args);
                    break;
                case "RegisterHeavyHardware":
                    this.systemMenager.RegisterHeavyHardware(args);
                    break;
                case "RegisterExpressSoftware":
                    this.systemMenager.RegisterExpressSoftware(args);
                    break;
                case "RegisterLightSoftware":
                    this.systemMenager.RegisterLightSoftware(args);
                    break;
                case "ReleaseSoftwareComponent":
                    this.systemMenager.ReleaseSoftwareComponent(args);
                    break;
                case "Analyze":
                    Console.WriteLine(this.systemMenager.Analyze());
                    break;
                case "Dump":
                    this.systemMenager.Dump(args);
                    break;
                case "Restore":
                    this.systemMenager.Restore(args);
                    break;
                case "Destroy":
                    this.systemMenager.Destroy(args);
                    break;
                case "DumpAnalyze":
                    Console.WriteLine(this.systemMenager.DumpAnalyze());
                    break;
                case "System Split":
                    var result = this.systemMenager.SystemSplit();
                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        Console.WriteLine(result);
                    }
                    return;
            }

            input = Console.ReadLine();
        }
    }
}
