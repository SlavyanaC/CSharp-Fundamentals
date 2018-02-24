using System;
using System.Collections.Generic;

public class Gandalf
{
    private int happinessPoints;

    public Gandalf()
    {
        this.happinessPoints = 0;
    }

    public int HappinessPoints => this.happinessPoints;

    public void Eat(string food)
    {
        Dictionary<string, int> foodHappinessPoints = new Dictionary<string, int>();
        foodHappinessPoints["cram"] = 2;
        foodHappinessPoints["lembas"] = 3;
        foodHappinessPoints["apple"] = 1;
        foodHappinessPoints["melon"] = 1;
        foodHappinessPoints["honeycake"] = 5;
        foodHappinessPoints["mushrooms"] = -10;

        if (foodHappinessPoints.ContainsKey(food.ToLower()))
            happinessPoints += foodHappinessPoints[food.ToLower()];
        else
            happinessPoints--;
    }

    private string CalculateMood()
    {
        if (this.happinessPoints <= -5)
            return "Angry";
        if (this.happinessPoints > -5 && this.happinessPoints <= 0)
            return "Sad";
        if (this.happinessPoints > 0 && this.happinessPoints <= 15)
            return "Happy";
        if (this.happinessPoints > 15)
            return "JavaScript";

        throw new ArgumentException();
    }

    public override string ToString()
    {
        string mood = this.CalculateMood();
        return $"{this.happinessPoints}" + 
               Environment.NewLine +
               $"{mood}";
    }
}
