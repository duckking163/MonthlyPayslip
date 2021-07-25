using System.Collections.Generic;

namespace MonthlyPayslip.Domain
{
    public static class TaxHelper
    {
        public static List<TaxBracket> TaxBrackets = new List<TaxBracket>
        {
            new TaxBracket
            {
                LowerBracket = 0,
                UpperBracket = 20000,
                TaxRate = 0
            },
            new TaxBracket
            {
                LowerBracket = 20000,
                UpperBracket = 40000,
                TaxRate = 0.1M
            },
            new TaxBracket
            {
                LowerBracket = 40000,
                UpperBracket = 80000,
                TaxRate = 0.2M
            },
            new TaxBracket
            {
                LowerBracket = 80000,
                UpperBracket = 180000,
                TaxRate = 0.3M
            },
            new TaxBracket
            {
                LowerBracket = 180000,
                UpperBracket = decimal.MaxValue,
                TaxRate = 0.4M
            },
        };

        public static decimal CalculateAnnualIncomeTax(decimal annualPretaxSalary)
        {
            var result = 0M;
            foreach (var taxBracket in TaxBrackets)
            {
                if (annualPretaxSalary <= taxBracket.LowerBracket)
                {
                    break;
                }

                result += (annualPretaxSalary - taxBracket.LowerBracket) * taxBracket.TaxRate;
            }
            return result;
        }
    }

    public class TaxBracket
    {
        public decimal LowerBracket { get; set; }
        public decimal UpperBracket { get; set; }
        public decimal TaxRate { get; set; }
    }
}
