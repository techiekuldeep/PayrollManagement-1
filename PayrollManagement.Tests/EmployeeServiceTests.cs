using System;
using System.Collections.Generic;
using System.Text;
using PayrollManagement.Services;
using Xunit;
using PayrollManagement.Models;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;

namespace PayrollManagement.Tests
{
    public class EmployeeServiceTests
    {
        private EmployeeService _employeeService;
        

        public EmployeeServiceTests()
        {
            var logger = Mock.Of<ILogger<MathRoundService>>();
            MathRoundService mathRoundService = new MathRoundService(logger);
            //MathRoundService mathRoundService = new MathRoundService();
            var logger2 = Mock.Of<ILogger<PayeTaxRateService>>();
            //MathRoundService mathRoundService = new MathRoundService(logger);
            PayeTaxRateService payeTaxRateService = new PayeTaxRateService(logger2, mathRoundService);
            var logger3 = Mock.Of<ILogger<EmployeeService>>();
            _employeeService = new EmployeeService(payeTaxRateService, mathRoundService,logger3);
        }
        
        [Fact]
        public void CalculatePayslip_ShouldReturnPayslip()
        {
            // Arrange
            Employee employee = new Employee
            {
                FirstName = "Kuldeep",
                LastName = "Singh",
                YearlySalary = 60050,
                SuperPercentage = 9,
                PaymentStartDate = "01 March – 31 March",
            };
            // Act
            Salaryslip actual = _employeeService.GetSalaryslip(employee);
            // Assert
            Salaryslip expected = new Salaryslip
            {
               EmployeeName = "Kuldeep Singh",
                GrossPay = 5004,
                IncomeTax = 922,
                NetPay = 4082,
                SalaryPeriod = "01 March – 31 March",
                Superannuation = 450
            };
            actual.ShouldBeEquivalentTo(expected);
        }

        [Fact]
        public void CalculatePayslip_ShouldReturnPayslip_WhenAnnualSalaryIs0_SuperRateIs0()
        {
            // Arrange
            Employee employee = new Employee
            {
                FirstName = "Kuldeep",
                LastName = "Singh",
                YearlySalary = 0,
                SuperPercentage = 0,
                PaymentStartDate = "01 March – 31 March",
            };
            // Act
            Salaryslip actual = _employeeService.GetSalaryslip(employee);
            // Assert
            Salaryslip expected = new Salaryslip
            {
                EmployeeName = "Kuldeep Singh",
                GrossPay = 0,
                IncomeTax = 0,
                NetPay = 0,
                SalaryPeriod = "01 March – 31 March",
                Superannuation = 0
            };
            actual.ShouldBeEquivalentTo(expected);
        }

        [Fact]
        public void CalculatePayslip_ShouldReturnPayslip_WhenAnnualSalaryIs0AndSuperRateIs50()
        {
            // Arrange
            Employee employee = new Employee
            {
                FirstName = "Kuldeep",
                LastName = "Singh",
                YearlySalary = 0,
                SuperPercentage = 0.50M,
                PaymentStartDate = "01 March – 31 March",
            };
            // Act
            Salaryslip actual = _employeeService.GetSalaryslip(employee);

            // Assert
            Salaryslip expected = new Salaryslip
            {
                EmployeeName = "Kuldeep Singh",
                GrossPay = 0,
                IncomeTax = 0,
                NetPay = 0,
                SalaryPeriod = "01 March – 31 March",
                Superannuation = 0
            };
            actual.ShouldBeEquivalentTo(expected);
        }
    }
}
