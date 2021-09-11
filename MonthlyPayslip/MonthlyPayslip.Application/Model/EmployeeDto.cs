namespace MonthlyPayslip.Application.Model
{
    public class EmployeeDto
    {
        public string EmployeeName { get; set; }

        public decimal AnnualSalary { get; set; }

        public decimal MonthlyPreTaxSalary { get; set; }

        public decimal MonthlyPostTaxSalary { get; set; }

        public decimal MonthlyIncomeTax { get; set; }

        public bool IsAustralianResident { get; set; }
    }
}
