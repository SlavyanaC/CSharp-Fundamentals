using System;

namespace _03.OldestFamilyMember
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var family = new Family();
            for (int i = 0; i < n; i++)
            {
                string[] member = Console.ReadLine().Split();
                var name = member[0];
                var age = int.Parse(member[1]);
                var person = new Person(name, age);
                family.AddMembers(person);
            }

            var oldestMember = family.GetOldestMember();
            Console.WriteLine(oldestMember.Name + " " + oldestMember.Age);
        }
    }
}
