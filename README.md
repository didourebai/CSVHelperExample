# CSVHelperExample
This project will explain how we can use CSVHelper library to read and write CSV files in faster an easier way.
Use CSV Helper in .NET Core
Introduction
If you need to read and write CSV files in faster, flexible and easy use, you can refer to CSV Helper that is a .NET open source library that include many features. The library is build on .NET Standard 2.0 which allows you to run almost in any environement. You can use it for Older versions of .NET.
Add CSV Helper
To add it to your .NET project (old framework or .NET Core), you can use Nuget package manager:
Nuget package manageror Package Manager Console:
Install-Package CsvHelper
Or .NET CLI Console
> dotnet add package CsvHelper
Case -Study : extract and write of an Employee CSV file
We will work on an example of an Employee.csv that include all informations related to an employee inside a company, and we would like extract all data to store it after in a database.
The file is in GitHub: https://github.com/didourebai/CSVHelperExample/blob/master/Employee.csv
According to your CSV headers, you can create a model to get all lines in a list of objects.
1- Create a model:
public class EmployeeModel
 {
 [Name(Constants.CsvHeaders.Firstname)]
 public string Firstname { get; set; }
[Name(Constants.CsvHeaders.Lastname)]
 public string Lastname { get; set; }
[Name(Constants.CsvHeaders.Address)]
 public string Address { get; set; }
[Name(Constants.CsvHeaders.City)]
 public string City { get; set; }
[Name(Constants.CsvHeaders.Mobile)]
 public string Mobile { get; set; }
[Name(Constants.CsvHeaders.Email)]
 public string Email { get; set; }
[Name(Constants.CsvHeaders.Salary)]
 public string Salary { get; set; }
[Name(Constants.CsvHeaders.Direction)]
 public string Direction { get; set; }
 }
2- Create a Mapper
public sealed class EmployeeMap : ClassMap<EmployeeModel>
 {
 public EmployeeMap()
 {
 Map(m => m.Firstname).Name(Constants.CsvHeaders.Firstname);
 Map(m => m.Lastname).Name(Constants.CsvHeaders.Lastname);
 Map(m => m.Address).Name(Constants.CsvHeaders.Address);
 Map(m => m.City).Name(Constants.CsvHeaders.City);
 Map(m => m.Mobile).Name(Constants.CsvHeaders.Mobile);
 Map(m => m.Email).Name(Constants.CsvHeaders.Email);
 Map(m => m.Salary).Name(Constants.CsvHeaders.Salary);
 Map(m => m.Direction).Name(Constants.CsvHeaders.Direction);
 }
 }
3- Add a CSV Parser service
We add a new interface including two operations: the first is to read and convert all data to list of objects and the second is to write a new CSV file.
public interface ICsvParserService
 {
 List<EmployeeModel> ReadCsvFileToEmployeeModel(string path);
 void WriteNewCsvFile(string path, List<EmployeeModel> employeeModels);
 }
Read from a CSV File
public class CsvParserService : ICsvParserService
 {
 public List<EmployeeModel> ReadCsvFileToEmployeeModel(string path)
 {
 try
 {
 using (var reader = new StreamReader(path, Encoding.Default))
 using (var csv = new CsvReader(reader))
 {
 csv.Configuration.RegisterClassMap<EmployeeMap>();
 var records = csv.GetRecords<EmployeeModel>().ToList();
 return records;
 }
 }
 catch (UnauthorizedAccessException e)
 {
 throw new Exception(e.Message);
 }
 catch (FieldValidationException e)
 {
 throw new Exception(e.Message);
 }
 catch (CsvHelperException e)
 {
 throw new Exception(e.Message);
 }
 catch (Exception e)
 {
 throw new Exception(e.Message);
 }
 }
 }
 }
Write in a CSV File
public void WriteNewCsvFile(string path, List<EmployeeModel> employeeModels)
 {
 using (StreamWriter sw = new StreamWriter(path, false, new UTF8Encoding(true)))
 using (CsvWriter cw = new CsvWriter(sw))
 {
 cw.WriteHeader<EmployeeModel>();
 cw.NextRecord();
 foreach (EmployeeModel emp in employeeModels)
 {
 cw.WriteRecord<EmployeeModel>(emp);
 cw.NextRecord();
 }
 }
 }
And this is the main to be able to test our function in the service:
static void Main(string[] args)
 {
 Console.WriteLine("**** Read a CSV file *****");
 var csvParserService = new CsvParserService();
 var path = @"C:\Users\didou\Documents\CSVHelperProject\Employee.csv";
 var result = csvParserService.ReadCsvFileToEmployeeModel(path);
var employeeToAdd = new EmployeeModel();
 result.Add(employeeToAdd);
 Console.WriteLine("**** Write a CSV file *****");
 csvParserService.WriteNewCsvFile(@"C:\Users\didou\Documents\CSVHelperProject\Employee1.csv", result);
 }
Conclusion
You can find the source code in GitHub: 
And a YouTube demo video in this link:
