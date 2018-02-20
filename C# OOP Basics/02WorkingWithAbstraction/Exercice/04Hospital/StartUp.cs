using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    public static void Main()
    {
        Dictionary<string, List<string>> docsPatients = new Dictionary<string, List<string>>();
        Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();


        string command = Console.ReadLine();
        while (command != "Output")
        {
            string[] tokens = command.Split();

            FillDepartmentsWithPatiensAndDoctors(docsPatients, departments, tokens);

            command = Console.ReadLine();
        }

        command = Console.ReadLine();

        while (command != "End")
        {
            string[] tokens = command.Split();
            PrintPatients(docsPatients, departments, tokens);
            command = Console.ReadLine();
        }
    }

    private static void PrintPatients(Dictionary<string, List<string>> docsPatients, Dictionary<string, List<List<string>>> departments, string[] tokens)
    {
        if (tokens.Length == 1)
        {
            Console.WriteLine(string.Join("\n", departments[tokens[0]].Where(x => x.Count > 0).SelectMany(x => x)));
        }
        else if (tokens.Length == 2 && int.TryParse(tokens[1], out int room))
        {
            Console.WriteLine(string.Join("\n", departments[tokens[0]][room - 1].OrderBy(x => x)));
        }
        else
        {
            Console.WriteLine(string.Join("\n", docsPatients[tokens[0] + tokens[1]].OrderBy(x => x)));
        }
    }

    private static void FillDepartmentsWithPatiensAndDoctors(Dictionary<string, List<string>> docsPatients, Dictionary<string, List<List<string>>> departments, string[] tokens)
    {
        string departament = tokens[0];
        string firstName = tokens[1];
        string lastName = tokens[2];
        string patient = tokens[3];
        string fullName = firstName + lastName;

        if (!docsPatients.ContainsKey(fullName))
        {
            docsPatients[fullName] = new List<string>();
        }
        if (!departments.ContainsKey(departament))
        {
            AddRooms(departments, departament);
        }

        bool hasRoomSpace = departments[departament].SelectMany(x => x).Count() < 60;
        if (hasRoomSpace)
        {
            AddPatientsToRooms(docsPatients, departments, departament, patient, fullName);
        }
    }

    private static void AddRooms(Dictionary<string, List<List<string>>> departments, string departament)
    {
        departments[departament] = new List<List<string>>();
        for (int rooms = 0; rooms < 20; rooms++)
        {
            departments[departament].Add(new List<string>());
        }
    }

    private static void AddPatientsToRooms(Dictionary<string, List<string>> docsPatients, Dictionary<string, List<List<string>>> departments, string departament, string patient, string fullName)
    {
        int room = 0;
        docsPatients[fullName].Add(patient);
        for (int st = 0; st < departments[departament].Count; st++)
        {
            if (departments[departament][st].Count < 3)
            {
                room = st;
                break;
            }
        }
        departments[departament][room].Add(patient);
    }
}