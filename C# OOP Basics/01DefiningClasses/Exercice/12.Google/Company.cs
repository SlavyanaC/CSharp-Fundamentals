using System.Text;

public class Company
{
    private string name;
    private string department;
    private string salary;

    public Company()
    {
        this.name = string.Empty;
        this.department = string.Empty;
        this.salary = string.Empty;
    }
    public Company(string name, string department, string salary)
        : this()
    {
        this.name = name;
        this.department = department;
        this.salary = salary;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Department
    {
        get { return department; }
        set { department = value; }
    }

    public string Salary
    {
        get { return salary; }
        set { salary = value; }
    }

    public override string ToString()
    {
        return $"{this.name} {this.department} {decimal.Parse(salary):f2}";
    }
}