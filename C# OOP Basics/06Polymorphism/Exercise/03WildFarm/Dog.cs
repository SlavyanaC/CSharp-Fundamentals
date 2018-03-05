using System;
using System.Linq;

public class Dog : Mammal
{
    private string[] eatableFood = new string[] { "Meat" };

    public Dog(string name, double weight, string region)
        : base(name, weight, region) { }

    public override void AskForFood()
    {
        Console.WriteLine("Woof!");
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
        double gainedWeight = this.FoodEaten * 0.40;
        double totalWeight = initialWeiht + gainedWeight;
        return $"{this.GetType().Name} [{this.Name}, {totalWeight}, {this.Region}, {FoodEaten}]";
    }
}
