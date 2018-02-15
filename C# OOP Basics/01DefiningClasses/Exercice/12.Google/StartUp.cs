using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.Google
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string inputLine = string.Empty;
            while ((inputLine = Console.ReadLine()) != "End")
            {
                var personInfo = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string personName = personInfo[0];
                string category = personInfo[1];
                switch (category)
                {
                    case "company":
                        people = ParseCompany(people, personInfo, personName);
                        break;
                    case "car":
                        people = ParseCar(people, personInfo, personName);
                        break;
                    case "pokemon":
                        people = ParsePokemon(people, personInfo, personName);
                        break;
                    case "parents":
                        people = ParseParent(people, personInfo, personName);
                        break;
                    case "children":
                        people = ParseChild(people, personInfo, personName);
                        break;
                }
            }

            string wantedPerson = Console.ReadLine();

            Person person = people.FirstOrDefault(p => p.Name == wantedPerson);
            if (person != null)
            {
                Console.Write(person.ToString());
            }
        }

        private static List<Person> ParseChild(List<Person> people, string[] personInfo, string personName)
        {
            string name = personInfo[2];
            string birthday = personInfo[3];

            var person = people.FirstOrDefault(p => p.Name == personName);
            if (person == null)
            {
                person = new Person(personName);
                people.Add(person);
            }
            var child = new Child(name, birthday);
            person.Children.Add(child);

            return people;
        }

        private static List<Person> ParseParent(List<Person> people, string[] personInfo, string personName)
        {
            string name = personInfo[2];
            string birthday = personInfo[3];

            var person = people.FirstOrDefault(p => p.Name == personName);
            if (person == null)
            {
                person = new Person(personName);
                people.Add(person);
            }
            var parent = new Parent(name, birthday);
            person.Parents.Add(parent);

            return people;
        }

        private static List<Person> ParsePokemon(List<Person> people, string[] personInfo, string personName)
        {
            string name = personInfo[2];
            string type = personInfo[3];

            var person = people.FirstOrDefault(p => p.Name == personName);
            if (person == null)
            {
                person = new Person(personName);
                people.Add(person);
            }
            var pokemon = new Pokemon(name, type);
            person.Pokemons.Add(pokemon);

            return people;
        }

        private static List<Person> ParseCar(List<Person> people, string[] personInfo, string personName)
        {
            string model = personInfo[2];
            string speed = personInfo[3];

            var person = people.FirstOrDefault(p => p.Name == personName);
            if (person == null)
            {
                person = new Person(personName);
                people.Add(person);
            }
            person.Car = new Car(model, speed);

            return people;
        }

        private static List<Person> ParseCompany(List<Person> people, string[] personInfo, string personName)
        {
            string company = personInfo[2];
            string department = personInfo[3];
            string salary = personInfo[4];

            var person = people.FirstOrDefault(p => p.Name == personName);
            if (person == null)
            {
                person = new Person(personName);
                people.Add(person);
            }
            person.Company = new Company(company, department, salary);

            return people;
        }
    }
}
