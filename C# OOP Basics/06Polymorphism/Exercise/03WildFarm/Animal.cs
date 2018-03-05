public abstract class Animal
{
    public string Name { get; set; }

    public double Weight { get; set; }

    public int FoodEaten { get; set; }

    public Animal(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
    }

    public abstract void AskForFood();

    public abstract void EatFood(Food food);
}
