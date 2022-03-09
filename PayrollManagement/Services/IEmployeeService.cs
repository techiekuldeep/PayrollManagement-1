using PayrollManagement.Models;

using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollManagement.Services
{
    public interface IEmployeeService
    {
        Salaryslip GetSalaryslip(Employee employee);
    }
}
