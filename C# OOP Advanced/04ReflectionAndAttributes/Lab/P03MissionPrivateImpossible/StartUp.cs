using System;

namespace P03MissionPrivateImpossible
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            var result = spy.RevealPrivateMethods("Hacker");
            Console.WriteLine(result);
        }
    }
}
