using System;
using System.Linq;

public class Mouse : Mammal
{
    public string[] eatableFood = new string[] { "Vegetable", "Fruit" };

    public Mouse(string name, double weight, string region)
        : base(name, weight, region) { }

    public override void AskForFood()
    {
        Console.WriteLine("Squeak");
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
        double gainedWeight = this.FoodEaten * 0.10;
        double totalWeight = initialWeiht + gainedWeight;
        return $"{this.GetType().Name} [{this.Name}, {totalWeight}, {this.Region}, {FoodEaten}]";
    }
}
