using System;
using System.Collections.Generic;
using System.Linq;

namespace _04ShoppingSpree
{
    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string[] inputPeople = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                string[] inputProducts = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                var people = new List<Person>();
                var products = new List<Product>();
                people = FillPeopleList(people, inputPeople);
                products = FillProductsList(products, inputProducts);
                string command = string.Empty;
                while ((command = Console.ReadLine()) != "END")
                {
                    var commandArgs = command.Split();
                    people = BuyProduct(people, products, commandArgs);
                }

                PrintOutput(people);
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }

        }

        private static void PrintOutput(List<Person> people)
        {
            foreach (var person in people)
            {
                if (person.Bag.Count > 0)
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.Bag.Select(p => p.Name))}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }

        private static List<Person> BuyProduct(List<Person> people, List<Product> products, string[] commandArgs)
        {
            var personName = commandArgs[0];
            var productName = commandArgs[1];
            Person person = people.FirstOrDefault(p => p.Name == personName);
            Product product = products.FirstOrDefault(p => p.Name == productName);
            if (people.Contains(person) && products.Contains(product))
            {
                if (person.Money >= product.Cost)
                {
                    person.Bag.Add(product);
                    person.BuyProduct(product);
                    Console.WriteLine($"{personName} bought {productName}");
                }
                else
                {
                    Console.WriteLine($"{personName} can't afford {productName}");
                }
            }
            return people;
        }

        private static List<Product> FillProductsList(List<Product> products, string[] inputProducts)
        {
            foreach (var product in inputProducts)
            {

                string[] tokens = product.Split('=');
                string name = tokens[0];
                decimal cost = decimal.Parse(tokens[1]);
                products.Add(new Product(name, cost));
            }

            return products;
        }

        private static List<Person> FillPeopleList(List<Person> people, string[] inputPeople)
        {
            foreach (var person in inputPeople)
            {
                string[] tokens = person.Split('=');
                string name = tokens[0];
                decimal money = decimal.Parse(tokens[1]);
                people.Add(new Person(name, money));
            }

            return people;
        }
    }
}
