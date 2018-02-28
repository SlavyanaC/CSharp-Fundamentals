using System;

namespace _04Telephony
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Smartphone smartphone = new Smartphone();
            string[] nums = Console.ReadLine().Split();
            foreach (var num in nums)
            {
                smartphone.Call(num);
            }
            string[] sites = Console.ReadLine().Split();
            foreach (var site in sites)
            {
                smartphone.Browse(site);
            }
        }
    }
}
