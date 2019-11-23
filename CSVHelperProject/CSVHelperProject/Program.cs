using CSVHelperProject.Models;
using CSVHelperProject.Services;
using System;

namespace CSVHelperProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Read a CSV file *****");
            var csvParserService = new CsvParserService();
            var path = @"C:\Users\didou\Documents\CSVHelperProject\Employee.csv";
            var result =  csvParserService.ReadCsvFileToEmployeeModel(path);

            var employeeToAdd = new EmployeeModel()
            {
                Address = "address 20",
                City = "city 20",
                Direction = "direction 20",
                Firstname = "first name 20",
                Email = "email20@mail.com",
                Lastname = "lastname 20",
                Mobile = "1111",
                Salary = "100000"
            };
            result.Add(employeeToAdd);
            Console.WriteLine("**** Write a CSV file *****");
            csvParserService.WriteNewCsvFile(@"C:\Users\didou\Documents\CSVHelperProject\Employee1.csv", result);
        }
    }
}
