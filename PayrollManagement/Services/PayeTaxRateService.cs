using Microsoft.Extensions.Logging;
using PayrollManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace PayrollManagement.Services
{
    public class PayeTaxRateService : IPayeTaxService
    {
        private readonly ILogger<PayeTaxRateService> _log;
        private  readonly IMathRoundService _mathRoundService;
        public PayeTaxRateService(ILogger<PayeTaxRateService> log,IMathRoundService mathRoundService)
        {
            _log = log;
            _mathRoundService = mathRoundService;
        }
        private static readonly IList<PayeTaxRate> PayeTaxRateList = new List<PayeTaxRate>()
            {
                new PayeTaxRate
                {
                    TaxableIncomeBracketStart  = 0,
                    TaxableIncomeBracketEnd= 18200,
                    TaxRate = 0M,
                    TaxableIncome  = 0,
                    BaseTax = 0
                },
                new PayeTaxRate
                {
                    TaxableIncomeBracketStart  = 18201,
                    TaxableIncomeBracketEnd = 37000,
                    TaxRate = 0.19M,
                    TaxableIncome = 18200,
                    BaseTax = 0
                },
                new PayeTaxRate
                {
                    TaxableIncomeBracketStart  = 37001,
                    TaxableIncomeBracketEnd = 87000,
                    TaxRate = 0.325M,
                    TaxableIncome= 37000,
                    BaseTax = 3572
                },
                new PayeTaxRate
                {
                    TaxableIncomeBracketStart  = 87001,
                    TaxableIncomeBracketEnd = 180000,
                    TaxRate = 0.37M,
                    TaxableIncome = 87000,
                    BaseTax = 19822
                },
                new PayeTaxRate
                {
                    TaxableIncomeBracketStart  = 180001,
                    TaxableIncomeBracketEnd = int.MaxValue,
                    TaxRate = 0.45M,
                    TaxableIncome = 180000,
                    BaseTax = 54232
                },
            };
        public int CalculatePayeTax(int yearlySalary)
        {
            PayeTaxRate payeTaxRate = PayeTaxRateList.Single(x => x.TaxableIncomeBracketStart <= yearlySalary && yearlySalary <= x.TaxableIncomeBracketEnd);
            var taxbeforeRounding = (payeTaxRate.BaseTax + ((yearlySalary-payeTaxRate.TaxableIncome)*payeTaxRate.TaxRate))/ 12;
            var taxAfterRounding = _mathRoundService.Round((double)taxbeforeRounding);
            return taxAfterRounding;
        }
    }
}
