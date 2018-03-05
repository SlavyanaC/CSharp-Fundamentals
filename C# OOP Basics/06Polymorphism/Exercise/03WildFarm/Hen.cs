using System;

public class Hen : Bird
{
    public Hen(string name, double weight, double wingSize)
        : base(name, weight, wingSize) { }

    public override void AskForFood()
    {
        Console.WriteLine("Cluck");
    }

    public override void EatFood(Food food)
    {
        this.FoodEaten += food.Quantity;
    }

    public override string ToString()
    {
        double initialWeiht = this.Weight;
        double gainedWeight = this.FoodEaten * 0.35;
        double totalWeight = initialWeiht + gainedWeight;
        return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {totalWeight}, {FoodEaten}]";
    }
}
