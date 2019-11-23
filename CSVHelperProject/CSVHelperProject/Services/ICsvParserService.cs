using CSVHelperProject.Models;
using System.Collections.Generic;

namespace CSVHelperProject.Services
{
    public interface ICsvParserService
    {
        List<EmployeeModel> ReadCsvFileToEmployeeModel(string path);
        void WriteNewCsvFile(string path, List<EmployeeModel> employeeModels);
    }
}
