using LastEFHW.DB_Context;
using LastEFHW.Models;

using var context = new CompaniesDBContext();

var company = new Company { Name = "BP" };
var employee = new Employee { Name = "Laman", Surname = "Aliyeva", Company = company };
var employee2 = new Employee { Name = "Erwin", Surname = "Smith", Company = company };

context.Companies.Add(company);
context.Employees.Add(employee);

context.SaveChanges();

var getEmployee = context.Employees.Find(employee.ID);

Console.WriteLine($"Employee: {getEmployee.Name}\n\n");


getEmployee.Name = "Caroline Raven";
context.SaveChanges();


context.Employees.Remove(getEmployee);
context.SaveChanges();

var employees = context.Employees.ToList();

foreach (var item in employees)
{
    Console.WriteLine($"Company: {item.Company.Name}\nEmployee: {item.Name}\nSurname: {item.Surname}");
}
