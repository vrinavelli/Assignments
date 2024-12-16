using System;
using System.Collections.Generic;

public abstract class Employee
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string ReportingManager { get; set; }

    protected Employee(int id, string name, string reportingManager)
    {
        ID = id;
        Name = name;
        ReportingManager = reportingManager;
    }

    public abstract void DisplayDetails();
}

public class ContractEmployee : Employee
{
    public DateTime ContractDate { get; set; }
    public int Duration { get; set; } // in months
    public decimal Charges { get; set; }

    public ContractEmployee(int id, string name, string reportingManager, DateTime contractDate, int duration, decimal charges)
        : base(id, name, reportingManager)
    {
        ContractDate = contractDate;
        Duration = duration;
        Charges = charges;
    }

    public override void DisplayDetails()
    {
        Console.WriteLine($"ID: {ID}, Name: {Name}, Reporting Manager: {ReportingManager}, Contract Date: {ContractDate.ToShortDateString()}, Duration: {Duration} months, Charges: {Charges:C}");
    }
}

public class PayrollEmployee : Employee
{
    public DateTime JoiningDate { get; set; }
    public int Experience { get; set; } // in years
    public decimal BasicSalary { get; set; }
    public decimal DA { get; private set; }
    public decimal HRA { get; private set; }
    public decimal PF { get; private set; }
    public decimal NetSalary { get; private set; }

    public PayrollEmployee(int id, string name, string reportingManager, DateTime joiningDate, int experience, decimal basicSalary)
        : base(id, name, reportingManager)
    {
        JoiningDate = joiningDate;
        Experience = experience;
        BasicSalary = basicSalary;
        CalculateSalaryComponents();
    }

    private void CalculateSalaryComponents()
    {
        if (Experience > 10)
        {
            DA = BasicSalary * 0.10m;
            HRA = BasicSalary * 0.085m;
            PF = 6200;
        }
        else if (Experience > 7)
        {
            DA = BasicSalary * 0.07m;
            HRA = BasicSalary * 0.065m;
            PF = 4100;
        }
        else if (Experience > 5)
        {
            DA = BasicSalary * 0.041m;
            HRA = BasicSalary * 0.038m;
            PF = 1800;
        }
        else
        {
            DA = BasicSalary * 0.019m;
            HRA = BasicSalary * 0.02m;
            PF = 1200;
        }

        NetSalary = BasicSalary + DA + HRA - PF;
    }

    public override void DisplayDetails()
    {
        Console.WriteLine($"ID: {ID}, Name: {Name}, Reporting Manager: {ReportingManager}, Joining Date: {JoiningDate.ToShortDateString()}, Experience: {Experience} years, Basic Salary: {BasicSalary:C}, DA: {DA:C}, HRA: {HRA:C}, PF: {PF:C}, Net Salary: {NetSalary:C}");
    }
}

public class Program
{
    public static void Main()
    {
        List<Employee> employees = new List<Employee>
        {
            new ContractEmployee(1, "Harsha", "Manager A", new DateTime(2023, 1, 1), 12, 5000),
            new PayrollEmployee(2, "Ravi", "Manager B", new DateTime(2015, 6, 1), 8, 60000),
            new PayrollEmployee(3, "Bahubali", "Manager C", new DateTime(2010, 3, 1), 12, 80000)
        };

        foreach (var employee in employees)
        {
            employee.DisplayDetails();
        }

        Console.WriteLine($"Total number of employees: {employees.Count}");
    }
}
