using CsvHelper.Configuration;
using CSVHelperProject.Models;

namespace CSVHelperProject.Mappers
{
    public sealed class EmployeeMap : ClassMap<EmployeeModel>
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
}
