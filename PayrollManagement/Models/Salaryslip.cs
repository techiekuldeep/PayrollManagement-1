using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper.Configuration.Attributes;

namespace PayrollManagement.Models
{
    public class Salaryslip
    {
        [Name(Constants.CsvHeaders.EmployeeName)]
        public string EmployeeName { get; set; }
        [Name(Constants.CsvHeaders.SalaryPeriod)]
        public string SalaryPeriod { get; set; }
        [Name(Constants.CsvHeaders.GrossPay)]
        public int GrossPay { get; set; }
        [Name(Constants.CsvHeaders.IncomeTax)]
        public int IncomeTax { get; set; }
        [Name(Constants.CsvHeaders.NetPay)]
        public int NetPay { get; set; }
        [Name(Constants.CsvHeaders.Superannuation)]
        public int Superannuation { get; set; }
    }
}
