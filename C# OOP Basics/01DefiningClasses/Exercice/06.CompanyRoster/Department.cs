using System.Collections.Generic;
using System.Linq;

public class Department
{
    private List<Employee> employees;
    string name;

    public Department(string name)
    {
        this.Employees = new List<Employee>();
        this.name = name;
    }

    public string Name
    {
        get{ return this.name;}
        set {this.name = value; }
    }

    public List<Employee> Employees
    {
        get { return employees; }
        private set { this.employees = value; }
    }

    public decimal AverageSalary => this.Employees.Select(e => e.Salary).Average();

    public  void AddEmployee(Employee employee)
    {
        this.Employees.Add(employee);
    }
}