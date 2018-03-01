using System;
using System.Collections.Generic;
using System.Linq;

namespace _08MilitaryElite
{
    class StartUp
    {
        private static List<ISoldier> soldiers = new List<ISoldier>();

        static void Main()
        {
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                var tokens = command.Split();
                string soldiertype = tokens[0];

                int id = int.Parse(tokens[1]);
                string firstName = tokens[2];
                string lastName = tokens[3];

                switch (soldiertype)
                {
                    case "Private":
                        AddPrivate(tokens, id, firstName, lastName);
                        break;
                    case "LeutenantGeneral":
                        AddLeutenantGeneral(tokens, id, firstName, lastName);
                        break;
                    case "Engineer":
                        AddEngineer(tokens, id, firstName, lastName);
                        break;
                    case "Commando":
                        AddCommando(tokens, id, firstName, lastName);
                        break;
                    case "Spy":
                        AddSpy(tokens, id, firstName, lastName);
                        break;
                }
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier.ToString());
            }
        }

        private static void AddSpy(string[] tokens, int id, string firstName, string lastName)
        {
            int codeNumber = int.Parse(tokens[4]);
            Spy spy = new Spy(id, firstName, lastName, codeNumber);
            soldiers.Add(spy);
        }

        private static void AddCommando(string[] tokens, int id, string firstName, string lastName)
        {
            double salary = double.Parse(tokens[4]);
            string corps = tokens[5];
            if (corps == "Airforces" || corps == "Marines") 
            {
                Commando commando = new Commando(id, firstName, lastName, salary, corps);
                for (int i = 6; i < tokens.Length; i += 2)
                {
                    var codeName = tokens[i];
                    var state = tokens[i + 1];
                    if (state == "Finished" || state == "inProgress")
                    {
                        commando.Missions.Add(new Mission(codeName, state));
                    }
                }

                soldiers.Add(commando);
            }
        }

        private static void AddEngineer(string[] tokens, int id, string firstName, string lastName)
        {
            double salary = double.Parse(tokens[4]);
            string corps = tokens[5];
            if (corps == "Airforces" || corps == "Marines") 
            {
                Engineer engeneer = new Engineer(id, firstName, lastName, salary, corps);
                for (int i = 6; i < tokens.Length; i += 2)
                {
                    var partName = tokens[i];
                    var hours = int.Parse(tokens[i + 1]);
                    engeneer.Repairs.Add(new Repair(partName, hours));
                }

                soldiers.Add(engeneer);
            }
        }

        private static void AddLeutenantGeneral(string[] tokens, int id, string firstName, string lastName)
        {
            double salary = double.Parse(tokens[4]);
            LeutenantGeneral leutenantGeneral = new LeutenantGeneral(id, firstName, lastName, salary);
            for (int i = 5; i < tokens.Length; i++)
            {
                var soldierId = int.Parse(tokens[i]);
                Private soldierToAdd = (Private)soldiers.FirstOrDefault(f => f.Id == soldierId);
                leutenantGeneral.AddPrivate(soldierToAdd);
            }

            soldiers.Add(leutenantGeneral);
        }

        private static void AddPrivate(string[] tokens, int id, string firstName, string lastName)
        {
            double salary = double.Parse(tokens[4]);
            Private @private = new Private(id, firstName, lastName, salary);
            soldiers.Add(@private);
        }
    }
}
