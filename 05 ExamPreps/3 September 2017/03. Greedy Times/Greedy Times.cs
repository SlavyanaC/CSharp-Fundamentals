using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._Greedy_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            long bagCpacity = long.Parse(Console.ReadLine());
            string[] itemsInput = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var goldBag = new Dictionary<string, long>();
            long goldQuantity = 0;

            var gemBag = new Dictionary<string, long>();
            long gemQuantity = 0;

            var cashBag = new Dictionary<string, long>();
            long cashQuantity = 0;

            for (int i = 0; i < itemsInput.Length; i += 2)
            {
                string itemName = itemsInput[i];
                long itemAmount = long.Parse(itemsInput[i + 1]);

                string itemType = GetItemType(itemName);
                bool canInsert = CanPutItemInBad(itemType, itemAmount, bagCpacity, goldQuantity, gemQuantity, cashQuantity);
                if (itemType == "invalid" || !canInsert)
                {
                    continue;
                }

                switch (itemType)
                {
                    case "Gold":
                        InsertItem(goldBag, itemName, itemAmount);
                        goldQuantity += itemAmount;
                        break;
                    case "Gem":
                        InsertItem(gemBag, itemName, itemAmount);
                        gemQuantity += itemAmount;
                        break;
                    case "Cash":
                        InsertItem(cashBag, itemName, itemAmount);
                        cashQuantity += itemAmount;
                        break;
                }
            }

            if (goldBag.Any())
            {
                Console.WriteLine(PrintBag(goldBag, "Gold", goldQuantity));
            }
            if (gemBag.Any())
            {
                Console.WriteLine(PrintBag(gemBag, "Gem", gemQuantity));
                if (cashBag.Any())
                {
                    Console.WriteLine(PrintBag(cashBag, "Cash", cashQuantity));
                }
            }
        }

        private static string PrintBag(Dictionary<string, long> bag, string type, long totalAmoun)
        {
            var resultBuilder = new StringBuilder();
            resultBuilder.AppendLine($"<{type}> ${totalAmoun}");
            foreach (var item in bag.OrderByDescending(i => i.Key).ThenBy(i => i.Value))
            {
                resultBuilder.AppendLine($"##{item.Key} - {item.Value}");
            }

            string result = resultBuilder.ToString().TrimEnd();
            return result;
        }

        private static void InsertItem(Dictionary<string, long> bag, string itemName, long itemAmount)
        {
            if (!bag.ContainsKey(itemName))
            {
                bag[itemName] = 0;
            }
            bag[itemName] += itemAmount;
        }

        private static bool CanPutItemInBad(string itemType, long itemAmount, long bagCpacity, long goldQuantity, long gemQuantity, long cashQuantity)
        {
            long bagOcupied = goldQuantity + gemQuantity + cashQuantity;
            if (bagCpacity < bagOcupied + itemAmount)
            {
                return false;
            }

            switch (itemType)
            {
                case "Gold":
                    return true;
                case "Gem":
                    gemQuantity += itemAmount;
                    return gemQuantity <= goldQuantity;
                case "Cash":
                    cashQuantity += itemAmount;
                    return cashQuantity <= gemQuantity;
            }

            return false;
        }

        private static string GetItemType(string itemName)
        {
            if (itemName.Length == 3)
            {
                return "Cash";
            }
            if (itemName.ToLower().EndsWith("gem"))
            {
                return "Gem";
            }
            if (itemName.ToLower() == "gold")
            {
                return "Gold";
            }
            return "invalid";
        }
    }
}
