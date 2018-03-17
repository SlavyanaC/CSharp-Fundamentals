using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SystemMenager
{
    private HardwareFactory hardwareFactory;
    private SoftwareFactory softwareFactory;

    private Dictionary<Hardware, List<Software>> system;
    private Dictionary<Hardware, List<Software>> dump;

    public SystemMenager()
    {
        this.hardwareFactory = new HardwareFactory();
        this.softwareFactory = new SoftwareFactory();
        this.system = new Dictionary<Hardware, List<Software>>();
        this.dump = new Dictionary<Hardware, List<Software>>();
    }

    public void RegisterPowerHardware(List<string> args)
    {
        var type = "power";
        var hardwareComponent = this.hardwareFactory.Create(type, args);
        this.system[hardwareComponent] = new List<Software>();
    }

    public void RegisterHeavyHardware(List<string> args)
    {
        var type = "heavy";
        var hardwareComponent = this.hardwareFactory.Create(type, args);
        this.system[hardwareComponent] = new List<Software>();
    }

    public void RegisterExpressSoftware(List<string> args)
    {
        var hardwareComponentName = args[0];
        var hardwareComponent = system.FirstOrDefault(c => c.Key.Name == hardwareComponentName).Key;

        var type = "express";
        var softwareComponent = this.softwareFactory.Create(type, args);
        if (system.ContainsKey(hardwareComponent))
        {
            if (hardwareComponent.Capacity >= softwareComponent.CapacityConsumption &&
                hardwareComponent.Memory >= softwareComponent.MemoryConsumption)
            {
                this.system[hardwareComponent].Add(softwareComponent);
            }
        }
    }

    public void RegisterLightSoftware(List<string> args)
    {
        var hardwareComponentName = args[0];
        var hardwareComponent = system.FirstOrDefault(c => c.Key.Name == hardwareComponentName).Key;

        var type = "light";
        var softwareComponent = this.softwareFactory.Create(type, args);
        if (system.ContainsKey(hardwareComponent))
        {
            if (hardwareComponent.Capacity >= softwareComponent.CapacityConsumption &&
                 hardwareComponent.Memory >= softwareComponent.MemoryConsumption)
            {
                this.system[hardwareComponent].Add(softwareComponent);
            }
        }
    }

    public void ReleaseSoftwareComponent(List<string> args)
    {
        var hardwareComponentName = args[0];
        var softwareComponentName = args[1];

        var hardwareComponent = system.FirstOrDefault(c => c.Key.Name == hardwareComponentName).Key;
        if (hardwareComponent != null)
        {
            var softwareComponent = system[hardwareComponent].FirstOrDefault(c => c.Name == softwareComponentName);
            if (softwareComponent != null)
            {
                system[hardwareComponent].Remove(softwareComponent);
            }
        }
    }

    public string Analyze()
    {
        var memoryInUse = this.system.Values.Sum(c => c.Sum(s => s.MemoryConsumption));
        var totalMemory = this.system.Sum(c => c.Key.Memory);

        var capacityInUse = this.system.Values.Sum(c => c.Sum(s => s.CapacityConsumption));
        var totalCapacity = this.system.Sum(c => c.Key.Capacity);

        var builder = new StringBuilder();
        builder.AppendLine("System Analysis");
        builder.AppendLine($"Hardware Components: {this.system.Count}");
        builder.AppendLine($"Software Components: {this.system.Sum(c => c.Value.Count)}");
        builder.AppendLine($"Total Operational Memory: {memoryInUse} / {totalMemory}");
        builder.AppendLine($"Total Capacity Taken: {capacityInUse} / {totalCapacity}");

        return builder.ToString().TrimEnd();
    }

    public string SystemSplit()
    {
        var builder = new StringBuilder();
        foreach (var hardComp in system)
        {
            var expresSoftCount = 0;
            var lightSoftCount = 0;
            foreach (var softComp in hardComp.Value)
            {
                if (softComp is ExpressSoftware)
                    expresSoftCount++;
                if (softComp is LightSoftware)
                    lightSoftCount++;
            }

            var memoryUsed = hardComp.Value.Sum(s => s.MemoryConsumption);
            var maxMemory = hardComp.Key.Memory;

            var capacityUsed = hardComp.Value.Sum(s => s.CapacityConsumption);
            var maxCapacity = hardComp.Key.Capacity;

            var components = hardComp.Value.Count == 0 ? " None" : string.Join(",", hardComp.Value.Select(s => s.Name));

            builder.AppendLine($"Hardware Component - {hardComp.Key.Name}");
            builder.AppendLine($"Express Software Components - {expresSoftCount}");
            builder.AppendLine($"Light Software Components - {lightSoftCount}");
            builder.AppendLine($"Memory Usage: {memoryUsed} / {maxMemory}");
            builder.AppendLine($"Capacity Usage: {capacityUsed} / {maxCapacity}");
            builder.AppendLine($"Type: {hardComp.Key.Type}");
            builder.AppendLine($"Software Components:{components}");
        }

        return builder.ToString().TrimEnd();
    }

    public void Dump(List<string> args)
    {
        var hardwareComponentName = args[0];
        var hardwareComponent = system.FirstOrDefault(c => c.Key.Name == hardwareComponentName);
        if (hardwareComponent.Key != null)
        {
            system.Remove(hardwareComponent.Key);
            dump.Add(hardwareComponent.Key, hardwareComponent.Value);
        }
    }

    public void Restore(List<string> args)
    {
        var hardwareComponentName = args[0];
        var hardwareComponent = dump.FirstOrDefault(c => c.Key.Name == hardwareComponentName);
        if (hardwareComponent.Key != null)
        {
            dump.Remove(hardwareComponent.Key);
            system.Add(hardwareComponent.Key, hardwareComponent.Value);
        }
    }

    public void Destroy(List<string> args)
    {
        var hardwareComponentName = args[0];
        var hardwareComponent = dump.FirstOrDefault(c => c.Key.Name == hardwareComponentName);
        if (hardwareComponent.Key != null)
        {
            dump.Remove(hardwareComponent.Key);
        }
    }

    public string DumpAnalyze()
    {
        var builder = new StringBuilder();

        var powerHardCount = 0;
        var heavyHardCount = 0;
        var expresSoftCount = 0;
        var lightSoftCount = 0;

        foreach (var hardComp in dump)
        {
            if (hardComp.Key is PowerHardware)
                powerHardCount++;
            if (hardComp.Key is HeavyHardware)
                heavyHardCount++;
            foreach (var softComp in hardComp.Value)
            {

                if (softComp is ExpressSoftware)
                    expresSoftCount++;
                if (softComp is LightSoftware)
                    lightSoftCount++;
            }
        }

        var totalDumpedMemory = dump.Values.Sum(c => c.Sum(s => s.MemoryConsumption));
        var totalDumpedCapacity = dump.Values.Sum(c => c.Sum(s => s.CapacityConsumption));

        builder.AppendLine("Dump Analysis");
        builder.AppendLine($"Power Hardware Components: {powerHardCount}");
        builder.AppendLine($"Heavy Hardware Components: {heavyHardCount}");
        builder.AppendLine($"Express Software Components: {expresSoftCount}");
        builder.AppendLine($"Light Software Components: {lightSoftCount}");
        builder.AppendLine($"Total Dumped Memory: {totalDumpedMemory}");
        builder.AppendLine($"Total Dumped Capacity: {totalDumpedCapacity}");

        return builder.ToString().TrimEnd();
    }
}
