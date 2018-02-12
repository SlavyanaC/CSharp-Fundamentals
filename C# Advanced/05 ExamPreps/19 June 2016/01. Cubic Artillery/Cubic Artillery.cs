using System;
using System.Collections.Generic;

namespace _01._Cubic_Artillery
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxCapacity = int.Parse(Console.ReadLine());
            Queue<string> bunkers = new Queue<string>();
            Queue<int> weapons = new Queue<int>();
            string command = string.Empty;

            int freeCapacity = maxCapacity;
            while ((command = Console.ReadLine()) != "Bunker Revision")
            {
                var tokens = command.Split();
                foreach (var token in tokens)
                {
                    try
                    {
                        var weaponCapacity = int.Parse(token);
                        bool isRoomForWeapon = false;
                        while (bunkers.Count > 1)
                        {
                            bool canBeContained = CheckIfWeaponCanBeContained(freeCapacity, weaponCapacity);
                            if (canBeContained)
                            {
                                weapons.Enqueue(weaponCapacity);
                                freeCapacity -= weaponCapacity;
                                isRoomForWeapon = true;
                                break;
                            }

                            if (weapons.Count == 0)
                            {
                                Console.WriteLine($"{bunkers.Peek()} -> Empty");
                            }
                            else
                            {
                                Console.WriteLine($"{bunkers.Peek()} -> {string.Join(", ", weapons)}");
                            }

                            bunkers.Dequeue();
                            weapons.Clear();
                            freeCapacity = maxCapacity;
                        }

                        if (!isRoomForWeapon)
                        {
                            bool canBeContained = CheckIfWeaponCanBeContained(maxCapacity, weaponCapacity);
                            if (canBeContained)
                            {
                                while (freeCapacity < weaponCapacity)
                                {
                                    int deletedItem = weapons.Dequeue();
                                    freeCapacity += deletedItem;
                                }
                                weapons.Enqueue(weaponCapacity);
                                freeCapacity -= weaponCapacity;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        var wantedBunker = token;
                        bunkers.Enqueue(wantedBunker);
                    }
                }
            }
        }

        private static bool CheckIfWeaponCanBeContained(int neededCapacity, int weaponCapacity)
        {
            return (neededCapacity >= weaponCapacity);
        }
    }
}
