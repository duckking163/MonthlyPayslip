using System;

namespace MonthlyPayslip.Domain
{
    public class Employee
    {
        public string EmployeeName { get; set; }

        public decimal AnnualSalary { get; set; }

        public decimal MonthlyPreTaxSalary { get; set; }

        public decimal MonthlyPostTaxSalary { get; set; }

        public decimal MonthlyIncomeTax { get; set; }

        public bool IsAustralianResident { get; set; }

        public Employee(string employeeName, decimal annualSalary, bool isAustralianResident)
        {
            EmployeeName = employeeName;
            AnnualSalary = annualSalary;
            IsAustralianResident = isAustralianResident;
        }

        public void PopulateMonthlySalary()
        {
            MonthlyPreTaxSalary = RoundDown(AnnualSalary/12,2);
            //var annualIncomeTax = IsAustralianResident? TaxHelper.CalculateAustralianAnnualIncomeTax(MonthlyPreTaxSalary*12) : TaxHelper.CalculateNonAustralianAnnualIncomeTax(MonthlyPreTaxSalary * 12);
            var annualIncomeTax = TaxHelper.CalculateAnnualIncomeTax(AnnualSalary, TaxHelper.AustralianTaxBracket);
            MonthlyIncomeTax = RoundDown(annualIncomeTax / 12, 2);
            MonthlyPostTaxSalary = MonthlyPreTaxSalary - MonthlyIncomeTax;
        }

        private static decimal RoundDown(decimal originalNumber, double decimalPlaces)
        {
            var power = Convert.ToDecimal(Math.Pow(10, decimalPlaces));
            return Math.Floor(originalNumber * power) / power;
        }
    }
}
