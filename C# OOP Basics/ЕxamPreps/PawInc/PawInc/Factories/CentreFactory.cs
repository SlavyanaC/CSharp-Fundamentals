using System;

public class CentreFactory
{
    public Centre Create(string type, string name)
    {
        switch (type)
        {
            case "cleansing":
                return new CleansingCenter(name);
            case "adoption":
                return new AdoptionCenter(name);
            default:
                throw new ArgumentException(ErrorMessages.InvalidCentreType);
        }
    }
}
