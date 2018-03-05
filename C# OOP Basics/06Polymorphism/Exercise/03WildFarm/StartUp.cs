using System;
using System.Collections.Generic;
using System.Linq;

namespace WildFarm
{
    class StartUp
    {
        private static List<Animal> animals = new List<Animal>();

        static void Main(string[] args)
        {
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                try
                {
                    var animalInfo = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    Animal animal = GetCurrentAnimal(animalInfo);

                    var foodInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    Food currentFood = GetCurrentFood(foodInfo);

                    animal.AskForFood();
                    animal.EatFood(currentFood);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }

        private static Food GetCurrentFood(string[] foodInfo)
        {
            string type = foodInfo[0];
            int quantity = int.Parse(foodInfo[1]);
            Food food;
            switch (type)
            {
                case "Vegetable":
                    food = new Vegetable(quantity);
                    return food;
                case "Fruit":
                    food = new Fruit(quantity);
                    return food;
                case "Meat":
                    food = new Meat(quantity);
                    return food;
                case "Seeds":
                    food = new Seeds(quantity);
                    return food;
            }

            throw new ArgumentException();
        }

        private static Animal GetCurrentAnimal(string[] animalInfo)
        {
            string type = animalInfo[0];
            string name = animalInfo[1];
            double weight = double.Parse(animalInfo[2]);
            double.TryParse(animalInfo[3], out double wingSize);
            string region = string.Empty;
            if (wingSize == 0.0)
            {
                region = animalInfo[3];
                if (animalInfo.Length == 4)
                {
                    switch (type)
                    {
                        case "Mouse":
                            animals.Add(new Mouse(name, weight, region));
                            break;
                        case "Dog":
                            animals.Add(new Dog(name, weight, region));
                            break;
                    }
                }
                else
                {
                    var breed = animalInfo[4];
                    switch (type)
                    {
                        case "Cat":
                            animals.Add(new Cat(name, weight, region, breed));
                            break;
                        case "Tiger":
                            animals.Add(new Tiger(name, weight, region, breed));
                            break;
                    }
                }
            }
            else
            {
                switch (type)
                {
                    case "Owl":
                        animals.Add(new Owl(name, weight, wingSize));
                        break;
                    case "Hen":
                        animals.Add(new Hen(name, weight, wingSize));
                        break;
                }
            }

            return animals.Last();
        }
    }
}
