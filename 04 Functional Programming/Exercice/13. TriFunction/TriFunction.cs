using System;
using System.Collections.Generic;
using System.Linq;

namespace _13._TriFunction
{
    class TriFunction
    {
        static void Main(string[] args)
        {
            int sumInput = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var filter = CreateFilter(sumInput);
            Console.WriteLine(names.FirstOrDefault(filter));
           
            /*First Option
            Console.WriteLine(names
                .FirstOrDefault(name =>
                name.ToCharArray()
                .Sum(c => c) >= sumInput)); */

            /*Second Option
            Func<string, int, bool> filter = (name, sum) => name.ToCharArray().Sum(c => c) >= sum;
            Console.WriteLine(names.FirstOrDefault(name => filter(name, sumInput)));*/

        }

        static Func<string, bool> CreateFilter (int sum)
        {
            return name => name.ToCharArray().Sum(c => c) >= sum;
        }
    }
}
