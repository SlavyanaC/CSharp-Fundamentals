using System;

class StartUp
{
    static void Main(string[] args)
    {
        string firstDate = Console.ReadLine();
        string secondDate = Console.ReadLine();
        Console.WriteLine(DateModifier.CalculateDifference(firstDate, secondDate));
    }
}
