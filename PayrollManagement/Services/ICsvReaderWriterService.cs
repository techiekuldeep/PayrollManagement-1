using PayrollManagement.Models;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagement.Services
{
    public interface ICsvReaderWriterService
    {
        Task<List<Employee>> ReadCsvFileToEmployeeModel();
        Task WriteNewCsvFile(List<Employee> employee);
        //void Run();
    }
}

