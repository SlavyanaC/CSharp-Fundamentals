using System;
using System.Collections.Generic;
using System.Linq;

namespace _05BorderControl
{
    class StartUp
    {
        static void Main()
        {
            List<IId> ids = new List<IId>();
            string input = string.Empty;
            while ((input = Console.ReadLine())!= "End")
            {
                string[] tokens = input.Split();
                if (tokens.Length == 3)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];
                    ids.Add(new Citizen(name, age, id));
                }
                else
                {
                    string model = tokens[0];
                    string id = tokens[1];
                    ids.Add(new Robot(model, id));
                }
            }

            string fakeId = Console.ReadLine();

            var detained = ids
                .Where(c => c.Id.EndsWith(fakeId))
                .Select(c => c.Id)
                .ToList();
            Console.WriteLine(string.Join(Environment.NewLine, detained));
        }
    }
}
