using System;
using System.Collections.Generic;

namespace _06Animals
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Beast!")
            {
                try
                {
                    string type = command;
                    string[] info = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    Animal animal;
                    switch (type)
                    {
                        case "Dog":
                            Dog dog = new Dog(info[0], int.Parse(info[1]), info[2]);
                            animals.Add(dog);
                            animal = dog;
                            break;
                        case "Frog":
                            Frog frog = new Frog(info[0], int.Parse(info[1]), info[2]);
                            animals.Add(frog);
                            break;
                        case "Cat":
                                Cat cat = new Cat(info[0], int.Parse(info[1]), info[2]);
                                animals.Add(cat);
                            break;
                        case "Kitten":
                            Kitten kitten = new Kitten(info[0], int.Parse(info[1]));
                            animals.Add(kitten);
                            break;
                        case "Tomcat":
                            Tomcat tomcat = new Tomcat(info[0], int.Parse(info[1]));
                            animals.Add(tomcat);
                            break;
                        default:
                            throw new ArgumentException("Invalid input!");
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
