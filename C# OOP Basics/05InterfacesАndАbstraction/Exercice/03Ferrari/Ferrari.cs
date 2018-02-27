using System;
using System.Collections.Generic;
using System.Text;

public class Ferrari : IFerrari
{
    string model = "488-Spider";
    public string Driver { get; private set; }

    public Ferrari(string driver)
    {
        this.Driver = driver;
    }

    public string Brakes()
    {
        return "Brakes!";
    }

    public string GasPedal()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{model}/{this.Brakes()}/{this.GasPedal()}/{this.Driver}";
    }
}
