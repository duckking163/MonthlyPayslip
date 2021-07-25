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

        public Employee(string employeeName, decimal annualSalary)
        {
            EmployeeName = employeeName;
            AnnualSalary = annualSalary;
        }

        public void PopulateMonthlySalary()
        {
            MonthlyPreTaxSalary = RoundDown(AnnualSalary/12,2);
            var annualIncomeTax = TaxHelper.CalculateAnnualIncomeTax(MonthlyPreTaxSalary*12);
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
