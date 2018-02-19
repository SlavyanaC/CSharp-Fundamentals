using System;

namespace _04Team
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            var team = new Team("Best team");
            for (int i = 0; i < lines; i++)
            {
                var tokens = Console.ReadLine().Split();
                var firstName = tokens[0];
                var lastName = tokens[1];
                var age = int.Parse(tokens[2]);
                var salary = decimal.Parse(tokens[3]);

                var person = new Person(firstName, lastName, age, salary);
                team.AddPerson(person);
            }

            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
        }
    }
}
