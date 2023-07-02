using System.Diagnostics.Metrics;
using Test.DB_Context;
using Test.Model;

using Database_Context context = new();

Company company1 = new Company { Name = "SM Group" };
Company company2 = new Company { Name = "YG Group" };
Company company3 = new Company { Name = "JYP Group" };

Employee emp1 = new Employee()
{
    Name = "Kai",
    Company = company1
};

Employee emp2 = new Employee()
{
    Name = "G-dragon",
    Company = company2
};

context.Companies.AddRange(company1, company2, company3);
context.Employees.AddRange(emp1, emp2);
context.SaveChanges();


foreach (var company in context.Companies)
{
    Console.WriteLine($"{company.Name}");
}

foreach (var employee in context.Employees)
{
    Console.WriteLine($"{employee.Name}, company: {employee.Company?.Name}");
}

