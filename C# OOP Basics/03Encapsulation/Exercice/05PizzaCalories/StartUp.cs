using System;

namespace _05PizzaCalories
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Pizza pizza = new Pizza();
            string input = string.Empty;
            try
            {
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] tokens = input.Split();
                    string ingredient = tokens[0];
                    switch (ingredient)
                    {
                        case "Pizza":
                            pizza = new Pizza(tokens[1]);
                            break;
                        case "Dough":
                            string doughType = tokens[1];
                            string bakingTechnique = tokens[2];
                            decimal doughWeight = decimal.Parse(tokens[3]);
                            pizza.Dough = new Dough(doughType, bakingTechnique, doughWeight);
                            break;
                        case "Topping":
                            string toppingType = tokens[1];
                            decimal toppingWeight = decimal.Parse(tokens[2]);
                            Topping topping = new Topping(toppingType, toppingWeight);
                            pizza.Toppings.Add(topping);
                            break;
                    }
                }

                if (pizza.Toppings.Count > 10 || pizza.Toppings.Count < 0)
                {
                    throw new ArgumentException($"Number of toppings should be in range [0..10].");
                }
                Console.WriteLine($"{pizza.Name} - {pizza.CalculateCalories():F2} Calories.");
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
        }
    }
}
