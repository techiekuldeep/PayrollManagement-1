using CsvHelper;
using Microsoft.Extensions.Logging;
using PayrollManagement.Mappers;
using PayrollManagement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagement.Services
{
    public class CsvReaderWriterService:ICsvReaderWriterService
    {
        private readonly ILogger<CsvReaderWriterService> _log;
        private readonly IEmployeeService _employeeService;
        private readonly CsvOptions _csvOptions;
        public CsvReaderWriterService(ILogger<CsvReaderWriterService> log, IEmployeeService employeeService, CsvOptions csvOptions)
        {
            _log = log;
            _employeeService = employeeService;
            _csvOptions = csvOptions;

        }
        public  async Task<List<Employee>> ReadCsvFileToEmployeeModel()
        {
            if (string.IsNullOrWhiteSpace(_csvOptions?.InputPath))
                throw new Exception("Input path not specified");
            try
            {
                //user async
                using (var reader = new StreamReader(_csvOptions.InputPath, Encoding.Default))
                using (var csv = new CsvReader(reader))
                {
                    csv.Configuration.RegisterClassMap<EmployeeMap>();
                    var records = csv.GetRecords<Employee>().ToList();
                    return records;
                }
            }
            
            catch (Exception e)
            {
                _log.LogError(e.Message);           
                throw new Exception($"Failed Reading CSV {_csvOptions.InputPath}");
            }
        }

        public async Task WriteNewCsvFile(List<Employee> listEmployees)
        {
            if (string.IsNullOrWhiteSpace(_csvOptions?.OutputPath))
                throw new Exception("Output path not specified");
            try {
                using (StreamWriter sw = new StreamWriter(_csvOptions.OutputPath, false, new UTF8Encoding(true)))
                using (CsvWriter cw = new CsvWriter(sw))
                {
                    List<Salaryslip> salaryslipList = new List<Salaryslip>();
                    foreach (var employee in listEmployees)
                    {
                        var salaryslip = _employeeService.GetSalaryslip(employee);

                        salaryslipList.Add(salaryslip);
                    }
                    //var csvWriter = new CsvWriter(file);
                    cw.WriteHeader<Salaryslip>();
                    cw.NextRecord();
                    foreach (Salaryslip salaryslip in salaryslipList)
                    {
                        cw.WriteRecord<Salaryslip>(salaryslip);
                        cw.NextRecord();
                    }
                }
                
            }
            catch (Exception e)
            {
                _log.LogError(e.Message);
                throw new Exception($"Failed Writing to  CSV {_csvOptions.OutputPath}");
            }
        }
    }
}


