using System;

namespace _03Ferrari
{
    class StartUp
    {
        static void Main()
        {
            string driver = Console.ReadLine();
            IFerrari ferrari = new Ferrari(driver);
            Console.WriteLine(ferrari);
        }
    }
}
