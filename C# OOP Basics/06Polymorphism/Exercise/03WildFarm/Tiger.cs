using System;
using System.Linq;

public class Tiger : Feline
{
    private string[] eatableFood = new string[] { "Meat" };

    public Tiger(string name, double weight, string region, string breed)
        : base(name, weight, region, breed) { }

    public override void AskForFood()
    {
        Console.WriteLine("ROAR!!!");
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
        double gainedWeight = this.FoodEaten * 1.00;
        double totalWeight = initialWeiht + gainedWeight;
        return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {totalWeight}, {this.Region}, {FoodEaten}]";
    }
}
