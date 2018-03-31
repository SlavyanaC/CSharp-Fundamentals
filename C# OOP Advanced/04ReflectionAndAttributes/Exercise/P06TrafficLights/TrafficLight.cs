using System;
using System.Collections.Generic;

public class TrafficLight
{
    Queue<SignalState> signals;

    public TrafficLight(SignalState signal)
    {
        this.signals = new Queue<SignalState>();
        SetSignals(signal);
    }

    public void SetSignals(SignalState signal)
    {
        int signalsCount = Enum.GetNames(typeof(SignalState)).Length;
        while (this.signals.Count != signalsCount)
        {
            this.signals.Enqueue(signal);
            var nextSignal = (int)signal + 1;
            if (nextSignal == signalsCount)
                nextSignal = 0;

            signal = (SignalState)nextSignal;
        }
    }

    public void ChangeSignal()
    {
        var oldSignal = this.signals.Dequeue();
        this.signals.Enqueue(oldSignal);
    }

    public SignalState Signal => this.signals.Peek();

    public override string ToString()
    {
        return this.Signal.ToString();
    }
}
