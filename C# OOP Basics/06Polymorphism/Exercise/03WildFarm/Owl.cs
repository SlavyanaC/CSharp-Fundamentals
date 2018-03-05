using System;
using System.Linq;

public class Owl : Bird
{
    private string[] eatableFood = new string[] { "Meat", };

    public Owl(string name, double weight, double wingSize)
        : base(name, weight, wingSize) { }

    public override void AskForFood()
    {
        Console.WriteLine("Hoot Hoot");
    }

    public override void EatFood(Food food)
    {
        if (!eatableFood.Contains(food.GetType().Name))
        {
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }

        this.FoodEaten += food.Quantity;
    }

    public override string ToString()
    {
        double initialWeiht = this.Weight;
        double gainedWeight = this.FoodEaten * 0.25;
        double totalWeight = initialWeiht + gainedWeight;
        return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {totalWeight}, {FoodEaten}]";
    }
}
