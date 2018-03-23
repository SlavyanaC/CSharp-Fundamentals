using System;

namespace P11Threeuple
{
    class StartUp
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)
            {
                var inputLine = Console.ReadLine().Split();
                Console.WriteLine(GetThreepleResult(inputLine));
            }
        }

        private static string GetThreepleResult(string[] inputLine)
        {
            if (inputLine.Length == 4)
            {
                var name = inputLine[0] + " " + inputLine[1];
                var address = inputLine[2];
                var town = inputLine[3];
                Threeuple<string, string, string> nameAddressTown = new Threeuple<string, string, string>
                {
                    First = name,
                    Second = address,
                    Third = town
                };
                return nameAddressTown.ToString();
            }

            int.TryParse(inputLine[1], out int beerLiters);
            if (beerLiters != 0)
            {
                var name = inputLine[0];
                bool drunk = false;
                if (inputLine[2].ToLower() == "drunk")
                {
                    drunk = true;
                }
                Threeuple<string, int, bool> nameLitersDrunkness = new Threeuple<string, int, bool>
                {
                    First = name,
                    Second = beerLiters,
                    Third = drunk
                };
                return nameLitersDrunkness.ToString();
            }
            else
            {
                var name = inputLine[0];
                double accountBalance = double.Parse(inputLine[1]);
                var bankName = inputLine[2];
                Threeuple<string, double, string> nameBalanceBank = new Threeuple<string, double, string>
                {
                    First = name,
                    Second = accountBalance,
                    Third = bankName
                };
                return nameBalanceBank.ToString();
            }
        }
    }
}
