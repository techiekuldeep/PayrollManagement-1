using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollManagement.Models
{
    public class PayeTaxRate
    {
        public int TaxableIncome { get; set; }

        public int BaseTax { get; set; }

        public decimal TaxRate { get; set; }

        public int TaxableIncomeBracketStart { get; set; }

        public int TaxableIncomeBracketEnd { get; set; }
    }
}
