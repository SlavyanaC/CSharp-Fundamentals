using System;

namespace P03Stack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Interpreter interpreter = new Interpreter();
            interpreter.Run();
        }
    }
}
