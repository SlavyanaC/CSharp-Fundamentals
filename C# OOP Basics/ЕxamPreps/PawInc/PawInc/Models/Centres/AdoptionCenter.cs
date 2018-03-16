using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AdoptionCenter : Centre
{
    public AdoptionCenter(string name)
        : base(name) { }

    public void SendForCleansing()
    {
        //foreach (var animal in this.StroredAnimals)
        //{
        //    animal.CleansingStatus = true;
        //}
    }
}
