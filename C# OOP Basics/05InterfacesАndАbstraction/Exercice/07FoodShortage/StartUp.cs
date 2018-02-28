using System;
using System.Collections.Generic;
using System.Linq;

namespace _07FoodShortage
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Citizen> citizens = new List<Citizen>();
            List<Rebel> rebels = new List<Rebel>();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                if (tokens.Length == 4)
                {
                    string id = tokens[2];
                    string birthdate = tokens[3];
                    citizens.Add(new Citizen(name, age, id, birthdate));
                }
                else
                {
                    string group = tokens[2];
                    rebels.Add(new Rebel(name, age));
                }
            }

            string command = string.Empty;
            int output = 0;
            while ((command = Console.ReadLine()) != "End")
            {
                if (citizens.Any(c => c.Name == command))
                {
                    var citizen = citizens.FirstOrDefault(c => c.Name == command);
                    citizen.BuyFood();
                    output += citizen.Food;
                }
                else if (rebels.Any(r => r.Name == command))
                {
                    var rebel = rebels.FirstOrDefault(r => r.Name == command);
                    rebel.BuyFood();
                    output += rebel.Food;
                }
            }
            Console.WriteLine(output);
        }
    }
}
