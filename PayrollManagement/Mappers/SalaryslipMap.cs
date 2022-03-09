using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper.Configuration;
using PayrollManagement.Models;

namespace PayrollManagement.Mappers
{
    public sealed class SalaryslipMap : ClassMap<Salaryslip>
    {
        public SalaryslipMap()
        {
            Map(m => m.EmployeeName).Name(Constants.CsvHeaders.EmployeeName);
            Map(m => m.SalaryPeriod).Name(Constants.CsvHeaders.SalaryPeriod);
            Map(m => m.GrossPay).Name(Constants.CsvHeaders.GrossPay);
            Map(m => m.IncomeTax).Name(Constants.CsvHeaders.IncomeTax);
            Map(m => m.NetPay).Name(Constants.CsvHeaders.NetPay);
            Map(m => m.Superannuation).Name(Constants.CsvHeaders.Superannuation);
        }
    }
        
}
