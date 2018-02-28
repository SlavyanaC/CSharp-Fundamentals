using System;
using System.Collections.Generic;
using System.Linq;

namespace _06BirthdayCelebrations
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthdate> birthdates = new List<IBirthdate>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();
                if (tokens[0] == "Citizen")
                {
                    string name = tokens[1];
                    int age = int.Parse(tokens[2]);
                    string id = tokens[3];
                    string birthdate = tokens[4];
                    birthdates.Add(new Citizen(name, age, id, birthdate));
                }
                else if (tokens[0] == "Pet")
                {
                    string name = tokens[1];
                    string birthdate = tokens[2];
                    birthdates.Add(new Pet(name, birthdate));
                }
            }

            string year = Console.ReadLine();
            var detained = birthdates
                .Where(c => c.Birthdate.EndsWith(year))
                .Select(c => c.Birthdate)
                .ToList();
            Console.WriteLine(string.Join(Environment.NewLine, detained));
        }
    }
}
