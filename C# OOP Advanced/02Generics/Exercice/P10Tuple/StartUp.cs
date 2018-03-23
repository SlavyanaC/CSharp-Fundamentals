using System;

namespace P10Tuple
{
    class StartUp
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)
            {
                var inputLine = Console.ReadLine().Split();
                Console.WriteLine(GetTupleResult(inputLine));
            }
        }

        private static string GetTupleResult(string[] inputLine)
        {
            if (inputLine.Length == 3)
            {
                var name = inputLine[0] + " " + inputLine[1];
                var address = inputLine[2];
                Tuple<string, string> nameAndAddres = new Tuple<string, string>(name, address);
                return nameAndAddres.ToString();
            }

            int integer;
            int.TryParse(inputLine[1], out integer);
            if (integer != 0)
            {
                var name = inputLine[0];
                var beerLiters = integer;
                Tuple<string, int> nameAndBeerLitres = new Tuple<string, int>(name, beerLiters);
                return nameAndBeerLitres.ToString();
            }
            else
            {
                var name = inputLine[0];
                var doubles = double.Parse(inputLine[1]);
                Tuple<string, double> nameAndDouble = new Tuple<string, double>(name, doubles);
                return nameAndDouble.ToString();
            }
        }
    }
}
