using System;
using System.Text;

public class Worker : Human
{
    private double weekSalary;
    private double workHoursPerDay;

    public Worker(string firstName, string lastName, double weekSalary, double workHours)
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHours;
    }

    public double WeekSalary
    {
        get { return weekSalary; }
        set
        {
            if (value < 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            weekSalary = value;
        }
    }

    public double WorkHoursPerDay
    {
        get { return workHoursPerDay; }
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            workHoursPerDay = value;
        }
    }

    public double SalaryPerHour => this.WeekSalary / (this.WorkHoursPerDay * 5);

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine($"First Name: {this.FirstName}");
        builder.AppendLine($"Last Name: {this.LastName}");
        builder.AppendLine($"Week Salary: {this.WeekSalary:F2}");
        builder.AppendLine($"Hours per day: {this.WorkHoursPerDay:F2}");
        builder.AppendLine($"Salary per hour: {this.SalaryPerHour:F2}");

        return builder.ToString().TrimEnd();
    }
}
