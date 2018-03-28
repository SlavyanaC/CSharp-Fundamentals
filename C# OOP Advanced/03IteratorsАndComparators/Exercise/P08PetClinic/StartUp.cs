using System;
using System.Collections.Generic;
using System.Linq;

namespace P08PetClinic
{
    class StartUp
    {
        static void Main()
        {
            List<Pet> pets = new List<Pet>();
            List<PetClinic> clinics = new List<PetClinic>();

            int commandCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandCount; i++)
            {
                string[] args = Console.ReadLine().Split();
                string command = args[0];

                switch (command)
                {
                    case "Create":
                        try
                        {
                            string typeCreation = args[1];
                            if (typeCreation == "Pet")
                            {
                                int age = int.Parse(args[3]);
                                Pet pet = new Pet(args[2], age, args[4]);
                                pets.Add(pet);
                            }
                            else
                            {
                                int roomsCount = int.Parse(args[3]);
                                PetClinic clinic = new PetClinic(args[2], roomsCount);
                                clinics.Add(clinic);
                            }
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case "Add":
                        Pet petToAdd = pets.FirstOrDefault(p => p.Name == args[1]);
                        PetClinic clinicToAdd = clinics.FirstOrDefault(c => c.Name == args[2]);
                        Console.WriteLine(clinicToAdd.Add(petToAdd));
                        break;

                    case "Release":
                        PetClinic clinicToRelease = clinics.FirstOrDefault(c => c.Name == args[1]);
                        Console.WriteLine(clinicToRelease.Realease());
                        break;

                    case "HasEmptyRooms":
                        PetClinic clinicToCheck = clinics.FirstOrDefault(c => c.Name == args[1]);
                        Console.WriteLine(clinicToCheck.HasEmptyRooms);
                        break;

                    case "Print":
                        PetClinic clinicToPrint = clinics.FirstOrDefault(c => c.Name == args[1]);
                        if (args.Length == 3)
                        {
                            int roomNum = int.Parse(args[2]);
                            Console.WriteLine(clinicToPrint.Print(roomNum));
                        }
                        else
                        {
                            Console.WriteLine(clinicToPrint.PrintAll());
                        }
                        break;
                }
            }
        }
    }
}
