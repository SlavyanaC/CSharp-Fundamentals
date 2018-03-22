using System;

namespace P05GenericCountMethodString
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var box = new Box<string>();
            for (int i = 0; i < count; i++)
            {
                box.Add(Console.ReadLine());
            }
            Console.WriteLine(box.GetCountOfGreaterElements(Console.ReadLine()));
        }
    }
}
