using System;

[SoftUni("Ventsi")]
class StartUp
{
    [SoftUni("Gosho")]
    static void Main()
    {
        Tracker tracker = new Tracker();
        Console.WriteLine(tracker.PrintMethodsByAuthor());
    }
}
