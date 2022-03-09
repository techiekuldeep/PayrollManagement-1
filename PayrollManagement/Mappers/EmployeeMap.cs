using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper.Configuration;
using PayrollManagement.Models;

namespace PayrollManagement.Mappers
{
    public sealed class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Map(m => m.FirstName).Name(Constants.CsvHeaders.FirstName);
            Map(m => m.LastName).Name(Constants.CsvHeaders.LastName);
            Map(m => m.YearlySalary).Name(Constants.CsvHeaders.YearlySalary);
            Map(m => m.SuperPercentage).Name(Constants.CsvHeaders.SuperPercentage);
            Map(m => m.PaymentStartDate).Name(Constants.CsvHeaders.PaymentStartDate);
        }
    }
}
