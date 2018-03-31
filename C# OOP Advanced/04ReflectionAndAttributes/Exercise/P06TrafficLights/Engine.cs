using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engine
{
    private readonly List<TrafficLight> trafficLights;

    public Engine()
    {
        this.trafficLights = new List<TrafficLight>();
    }

    public void Run()
    {
        SetLights();
        int count = int.Parse(Console.ReadLine());
        StringBuilder builder = new StringBuilder();
        foreach (var r in Enumerable.Range(0, count))
        {
            this.trafficLights.ForEach(t => t.ChangeSignal());
            builder.AppendLine(string.Join(" ", this.trafficLights));
        }

        Console.WriteLine(builder.ToString().TrimEnd());
    }

    private void SetLights()
    {
        string[] trafficLightSignals = Console.ReadLine().Split();
        foreach (var trafficLight in trafficLightSignals)
        {
            if (Enum.TryParse(trafficLight, out SignalState signal))
            {
                this.trafficLights.Add(new TrafficLight(signal));
            }
        }
    }

    private string ChangeSignal(TrafficLight trafficLight)
    {
        trafficLight.ChangeSignal();
        string result = trafficLight.Signal.ToString();

        return result;
    }
}
