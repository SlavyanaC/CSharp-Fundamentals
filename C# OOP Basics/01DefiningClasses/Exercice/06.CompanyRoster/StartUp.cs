using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.CompanyRoster
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Department> departments = new List<Department>();
            int peopleCount = int.Parse(Console.ReadLine());
            for (int person = 0; person < peopleCount; person++)
            {
                string[] empInput = Console.ReadLine().Split();

                string name = empInput[0];
                decimal salary = decimal.Parse(empInput[1]);
                string position = empInput[2];
                string depName = empInput[3];

                string email = "n/a";
                int age = -1;
                if (empInput.Length == 6)
                {
                    email = empInput[4];
                    age = int.Parse(empInput[5]);
                }
                else if (empInput.Length == 5)
                {
                    bool isAge = int.TryParse(empInput[4], out age);
                    if (!isAge)
                    {
                        email = empInput[4];
                        age = -1;
                    }
                }

                if (!departments.Any(d => d.Name == depName))
                {
                    Department dep = new Department(depName);
                    departments.Add(dep);
                }

                var department = departments.FirstOrDefault(d => d.Name == depName);
                Employee employee = new Employee(name, position, salary, age, email);
                department.AddEmployee(employee);   
            }

            var highestAvgDep = departments.OrderByDescending(d => d.AverageSalary).First();
            Console.WriteLine($"Highest Average Salary: {highestAvgDep.Name}");
            foreach (var emp in highestAvgDep.Employees.OrderByDescending(e => e.Salary))
            {
                Console.WriteLine($"{emp.Name} {emp.Salary:f2} {emp.Email} {emp.Age}");
            }
        }
    }
}
