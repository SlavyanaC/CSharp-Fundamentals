using System;

namespace ConsoleApp1
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var manager = new DraftManager();
            while (true)
            {
                var inputLine = Console.ReadLine();
                manager.CommandInterpreter(inputLine);
                if (inputLine == "Shutdown")
                {
                    break;
                }
            }
        }
    }
}
