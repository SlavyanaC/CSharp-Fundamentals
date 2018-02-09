namespace _03._Softuni_Numerals
{
    using System;
    using System.Numerics;

    class Program
    {
        static void Main(string[] args)
        {
            string base5String = ConvertStringToBase5(Console.ReadLine());
            Console.WriteLine(ConvertBase5toBase10(base5String));
        }

        private static BigInteger ConvertBase5toBase10(string base5String)
        {
            BigInteger result = 0;
            for (int i = 0; i < base5String.Length; i++)
            {
                BigInteger nextDigit = base5String[base5String.Length - 1 - i] - '0';
                result += nextDigit * BigInteger.Pow(5, i);
            }

            return result;
        }

        private static string ConvertStringToBase5(string str)
        {
            string[] digitCodes = { "aa", "aba", "bcc", "cc", "cdc" };
            var result = string.Empty;
            while (str.Length > 0)
            {
                for (int index = 0; index < digitCodes.Length; index++)
                {
                    string code = digitCodes[index];
                    if (str.StartsWith(code))
                    {
                        result += index;
                        str = str.Substring(code.Length);
                        break;
                    }
                }
            }

            return result;
        }
    }
}
