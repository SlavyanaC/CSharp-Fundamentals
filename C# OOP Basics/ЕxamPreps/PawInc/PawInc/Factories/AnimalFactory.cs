using System;
using System.Collections.Generic;

public class AnimalFactory
{
    public Animal Create(string type, List<string> args)
    {
        var name = args[0];
        var age = int.Parse(args[1]);
        switch (type)
        {
            case "dog":
                var learnedCommands = int.Parse(args[2]);
                return new Dog(name, age, learnedCommands);
            case "cat":
                var intelligenceCoefficient = int.Parse(args[2]);
                return new Cat(name, age, intelligenceCoefficient);
            default:
                throw new ArgumentException(ErrorMessages.InvalidAnimalType);
        }
    }
}
