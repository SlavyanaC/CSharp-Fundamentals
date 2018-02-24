using System;

namespace _05MordorsCruelPlan
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] foods = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Gandalf gandalf = new Gandalf();
            foreach (var food in foods)
            {
                gandalf.Eat(food);
            }
            Console.WriteLine(gandalf);
        }
    }
}
