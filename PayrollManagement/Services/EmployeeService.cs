using Microsoft.Extensions.Logging;
using PayrollManagement.Models;
using System;

namespace PayrollManagement.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ILogger<EmployeeService> _log;
        private readonly IPayeTaxService _payeTaxRateService;
        private readonly IMathRoundService _mathRoundService;

        public EmployeeService(IPayeTaxService payeTaxRateService, IMathRoundService mathRoundService, ILogger<EmployeeService> log )
        {
            _log = log;
            _payeTaxRateService = payeTaxRateService;
            _mathRoundService = mathRoundService;
        }
        
        public Salaryslip GetSalaryslip(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));
     
                ValidateSuperPercentage(employee);
                ValidateYearlySalary(employee);
                Salaryslip salaryslip = new Salaryslip();
                GetFullName(employee, salaryslip);
                GetSalaryPeriod(employee, salaryslip);
                GetGrosspay(employee, salaryslip);
                GetIncomeTax(employee, salaryslip);
                GetNetPay(salaryslip);
                GetSuperannuationAmount(employee, salaryslip);
                return salaryslip;
        }
        private void ValidateYearlySalary(Employee employee)
        {
            if (employee.YearlySalary < 0)
            {
                throw new OverflowException();
            }
        }
        private void ValidateSuperPercentage(Employee employee)
        {
            if (employee.SuperPercentage/100 > 0.5M || employee.SuperPercentage/100 < 0M)
            {
                throw new OverflowException();
            }
        }
        private void GetFullName(Employee employee, Salaryslip salaryslip)
        {
            salaryslip.EmployeeName = string.Format("{0} {1}", employee.FirstName, employee.LastName);
        }

        private void GetSalaryPeriod(Employee employee, Salaryslip salaryslip)
        {
            salaryslip.SalaryPeriod = employee.PaymentStartDate;
        }
        private void GetGrosspay(Employee employee, Salaryslip salaryslip)
        {
            salaryslip.GrossPay = _mathRoundService.Round(employee.YearlySalary/12);
        }

        private void GetIncomeTax(Employee employee, Salaryslip salaryslip)
        {
            salaryslip.IncomeTax = _payeTaxRateService.CalculatePayeTax(employee.YearlySalary);
        }
        private void GetNetPay(Salaryslip salaryslip)
        {
            salaryslip.NetPay = salaryslip.GrossPay - salaryslip.IncomeTax;
        }
        private void GetSuperannuationAmount(Employee employee, Salaryslip salaryslip)
        {
            salaryslip.Superannuation = _mathRoundService.Round((double)(salaryslip.GrossPay * employee.SuperPercentage/100));
        }
    }

    
}
