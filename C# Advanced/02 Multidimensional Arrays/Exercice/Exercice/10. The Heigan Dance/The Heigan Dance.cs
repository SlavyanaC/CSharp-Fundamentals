using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._The_Heigan_Dance
{
    // 70/100
    public class TheHeiganDance
    {
        public static void Main()
        {
            int playerRow = 15 / 2;
            int playerCol = 15 / 2;
            double heiganPoints = 3000000;
            double playerPoints = 18500;
            Dictionary<string, int> spellDamage = new Dictionary<string, int>()
            {
                {"Cloud", 3500 },
                {"Eruption", 6000 }

            };

            var spell = string.Empty;
            double damageToHeigan = double.Parse(Console.ReadLine());
            bool hasActiveCloud = false;
            while (heiganPoints > 0 && playerPoints > 0)
            {
                heiganPoints -= damageToHeigan;
                if (hasActiveCloud)
                {
                    playerPoints -= spellDamage["Cloud"];
                    hasActiveCloud = false;
                }

                if (heiganPoints < 0 || playerPoints < 0)
                {
                    break;
                }

                string[] spellAndCoordinates = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                spell = spellAndCoordinates[0];
                int hitRow = int.Parse(spellAndCoordinates[1]);
                int hitCol = int.Parse(spellAndCoordinates[2]);

                bool isHit = CheckIfCellIsHit(hitRow, hitCol, playerRow, playerCol);
                if (isHit)
                {
                    // UP
                    int escapeRow = playerRow - 1;
                    int escapeCol = playerCol;
                    if (!CheckIfCellIsHit(hitRow, hitCol, escapeRow, escapeCol) && CheckIfCellIsInside(escapeRow, escapeCol))
                    {
                        playerRow = escapeRow;
                        playerCol = escapeCol;
                        continue;
                    }

                    // RIGHT
                    escapeRow++;
                    escapeCol++;
                    if (!CheckIfCellIsHit(hitRow, hitCol, escapeRow,escapeCol) && CheckIfCellIsInside(escapeRow, escapeCol))
                    {
                        playerRow = escapeRow;
                        playerCol = escapeCol;
                        continue;
                    }

                    // DOWN
                    escapeRow++;
                    escapeCol--;
                    if (!CheckIfCellIsHit(hitRow, hitCol, escapeRow, escapeCol) && CheckIfCellIsInside(escapeRow, escapeCol))
                    {
                        playerRow = escapeRow;
                        playerCol = escapeCol;
                        continue;
                    }

                    // LEFT
                    escapeRow--;
                    escapeCol--;
                    if (!CheckIfCellIsHit(hitRow, hitCol, escapeRow, escapeCol) && CheckIfCellIsInside(escapeRow, escapeCol))
                    {
                        playerRow = escapeRow;
                        playerCol = escapeCol;
                        continue;
                    }

                    else
                    {
                        playerPoints -= spellDamage[spell];
                        if (spell == "Cloud")
                        {
                            hasActiveCloud = true;
                        }
                    }
                }
            }

            PrintOutput(heiganPoints, playerPoints, playerRow, playerCol, spell);
        }

        private static void PrintOutput(double heiganPoints, double playerPoints, int playerRow, int playerCol, string spell)
        {
            if (heiganPoints <= 0)
            {
                Console.WriteLine("Heigan: Defeated!");
            }
            else
            {
                Console.WriteLine($"Heigan: {heiganPoints:f2}");
            }
            if (spell == "Cloud")
            {
                spell = "Plague " + spell;
            }
            if (playerPoints <= 0)
            {
                Console.WriteLine($"Player: Killed by {spell}");
            }
            else
            {
                Console.WriteLine($"Player: {playerPoints:f0}");
            }
            Console.WriteLine($"Final position: {playerRow}, {playerCol}");
        }

        private static bool CheckIfCellIsInside(int escapeRow, int escapeCol)
        {
            int rowCount = 15;
            int colCount = 15;
            if (escapeRow < 0 || escapeRow >= rowCount ||
                escapeCol < 0 || escapeCol >= colCount)
            {
                return false;
            }

            return true;
        }

        private static bool CheckIfCellIsHit(int hitRow, int hitCol, int playerRow, int playerCol)
        {
            return (playerRow >= hitRow - 1 && playerRow <= hitRow + 1 &&
                    playerCol >= hitCol - 1 && playerCol <= hitCol + 1);
        }
    }
}