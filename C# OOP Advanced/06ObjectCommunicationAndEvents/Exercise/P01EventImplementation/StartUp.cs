using System;

namespace P01EventImplementation
{
    class StartUp
    {
        static void Main()
        {
            Dispatcher dispatcher = new Dispatcher();
            Handler handler = new Handler();

            dispatcher.NameChange += handler.OnDispatcherNameChange;
            var name = string.Empty;
            while ((name = Console.ReadLine()) != "End")
            {
                dispatcher.Name = name;
            }
        }
    }
}
