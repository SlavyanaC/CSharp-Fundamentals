using System;

namespace P06GenericCountMethodDouble
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var box = new Box<double>();
            for (int i = 0; i < count; i++)
            {
                box.Add(double.Parse(Console.ReadLine()));
            }
            Console.WriteLine(box.GetCountOfGreaterElements(double.Parse(Console.ReadLine())));
        }
    }
}
