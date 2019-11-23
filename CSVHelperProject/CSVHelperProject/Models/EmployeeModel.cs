using CsvHelper.Configuration.Attributes;

namespace CSVHelperProject.Models
{
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
}
