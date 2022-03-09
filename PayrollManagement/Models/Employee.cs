using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper.Configuration.Attributes;
namespace PayrollManagement.Models
{
    public class Employee
    {
        [Name(Constants.CsvHeaders.FirstName)]
        public string FirstName { get; set; }
        [Name(Constants.CsvHeaders.LastName)]
        public string LastName { get; set; }
        [Name(Constants.CsvHeaders.YearlySalary)]
        public int YearlySalary { get; set; }
        [Name(Constants.CsvHeaders.SuperPercentage)]
        public decimal SuperPercentage { get; set; }
        [Name(Constants.CsvHeaders.PaymentStartDate)]
        public string PaymentStartDate { get; set; }
    }
}
