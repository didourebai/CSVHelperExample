using CsvHelper;
using CSVHelperProject.Mappers;
using CSVHelperProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSVHelperProject.Services
{
    public class CsvParserService : ICsvParserService
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
    }
}

