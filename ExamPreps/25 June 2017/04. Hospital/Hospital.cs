using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Hospital
{
    // 80/100
    class Hospital
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> departmentsWithPatients = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> doctorsWithPatients = new Dictionary<string, List<string>>();

            var command = string.Empty;
            while ((command = Console.ReadLine()) != "Output")
            {
                var commandArgs = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var department = commandArgs[0];
                var doctor = $"{commandArgs[1]} {commandArgs[2]}";
                var patient = commandArgs[3];

                bool thereIsPlace = CheckIfThereIsPlace(department, patient, departmentsWithPatients);
                if (thereIsPlace)
                {
                    departmentsWithPatients = AddPatientToDepartment(department, patient, departmentsWithPatients);
                    doctorsWithPatients = AddPatientToDoctor(doctor, patient, doctorsWithPatients);
                }
            }

            var output = string.Empty;
            while ((output = Console.ReadLine().Trim()) != "End")
            {
                var outputArgs = output.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (departmentsWithPatients.ContainsKey(output))
                {
                    var department = output;
                    PrintDepartmentsPatients(department, departmentsWithPatients);
                }
                else if (doctorsWithPatients.ContainsKey(output))
                {
                    var doctor = output;
                    PrintDoctorsPatients(doctor, doctorsWithPatients);
                }
                else
                {
                    var tokens = output.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    var department = tokens[0];
                    var room = int.Parse(tokens[1]);

                    int startIndex = 0;
                    int endindex = 0;
                    for (int r = 1; r <= room; r++)
                    {
                        if (r == 1)
                        {
                            startIndex = 0;
                            endindex = 2;
                        }
                        else
                        {
                            startIndex += 3;
                            endindex += 3;
                        }
                    }

                    PrintPatientsFromDepartmentRoom(startIndex, endindex, department, departmentsWithPatients);
                }
            }
        }

        private static void PrintPatientsFromDepartmentRoom(int startIndex, int endindex, string department, Dictionary<string, List<string>> departmentsWithPatients)
        {
            List<string> patient = new List<string>();
            var lastPatient = departmentsWithPatients[department].Count - 1;
            if (startIndex > lastPatient)
            {
                return;
            }
            if (endindex > lastPatient)
            {
                endindex = lastPatient;
            }

            for (int i = startIndex; i <= endindex; i++)
            {
                patient.Add(departmentsWithPatients[department][i]);
            }

            foreach (var patien in patient.OrderBy(p => p))
            {
                Console.WriteLine(patien);
            }
        }

        private static void PrintDoctorsPatients(string doctor, Dictionary<string, List<string>> doctorsWithPatients)
        {

            foreach (var patient in doctorsWithPatients[doctor].OrderBy(p => p))
            {
                Console.WriteLine(patient);
            }
        }

        private static void PrintDepartmentsPatients(string department, Dictionary<string, List<string>> departmentsWithPatients)
        {
            foreach (var patient in departmentsWithPatients[department])
            {
                Console.WriteLine(patient);
            }
        }

        private static bool CheckIfThereIsPlace(string department, string patient, Dictionary<string, List<string>> departmentsWithPatients)
        {
            if (!departmentsWithPatients.ContainsKey(department))
            {
                return true;
            }
            else if (departmentsWithPatients[department].Count < 60)
            {
                return true;
            }

            return false;
        }

        private static Dictionary<string, List<string>> AddPatientToDoctor(string doctor, string patient, Dictionary<string, List<string>> doctorsWithPatients)
        {
            if (!doctorsWithPatients.ContainsKey(doctor))
            {
                doctorsWithPatients.Add(doctor, new List<string>());
                doctorsWithPatients[doctor].Add(patient);
            }
            else
            {
                doctorsWithPatients[doctor].Add(patient);
            }

            return doctorsWithPatients;
        }

        private static Dictionary<string, List<string>> AddPatientToDepartment(string department, string patient, Dictionary<string, List<string>> departmentsWithPatients)
        {
            if (!departmentsWithPatients.ContainsKey(department))
            {
                departmentsWithPatients.Add(department, new List<string>());
                departmentsWithPatients[department].Add(patient);
            }
            else
            {
                departmentsWithPatients[department].Add(patient);
            }

            return departmentsWithPatients;
        }
    }
}