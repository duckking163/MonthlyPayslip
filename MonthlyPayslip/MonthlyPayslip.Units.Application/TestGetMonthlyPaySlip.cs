using MonthlyPayslip.Application.Query;
using System.Threading;
using Xunit;

namespace MonthlyPayslip.Units.Application
{
    public class TestGetMonthlyPaySlip
    {
        private readonly GetMonthlyPayslipByAnnualSalaryQuery.Handler _handler;

        public TestGetMonthlyPaySlip()
        {
            _handler = new GetMonthlyPayslipByAnnualSalaryQuery.Handler();
        }

        [Theory]
        [InlineData("John Miller", 60000, 5000, 4500, 500)]
        [InlineData("John Miller", 18000, 1500, 1500, 0)]
        [InlineData("John Miller", 36000, 3000, 2866.67, 133.33)]
        [InlineData("John Miller", 120000, 10000, 8166.67, 1833.33)]
        [InlineData("John Miller", 240000, 20000,  14666.67, 5333.33)]
        public async void TestGetMonthlyPayslipForAustralianResident(string name, decimal annualSalary, decimal monthlyPretax, decimal monthlyPostTax, decimal monthlyTax)
        {
            var employee = await _handler.Handle(new GetMonthlyPayslipByAnnualSalaryQuery.Query
            {
                Name = name,
                AnnualSalary = annualSalary,
                IsAustralianResident = true
            }, CancellationToken.None);
            Assert.Equal(monthlyPretax, employee.MonthlyPreTaxSalary);
            Assert.Equal(monthlyTax, employee.MonthlyIncomeTax);
            Assert.Equal(monthlyPostTax, employee.MonthlyPostTaxSalary);
        }

        [Theory]
        [InlineData("John Miller", 60000, 5000, 4166.67, 833.33)]
        //[InlineData("John Miller", 18000, 1500, 1500, 0)]
        //[InlineData("John Miller", 36000, 3000, 2866.67, 133.33)]
        //[InlineData("John Miller", 120000, 10000, 8166.67, 1833.33)]
        //[InlineData("John Miller", 240000, 20000, 14666.67, 5333.33)]
        public async void TestGetMonthlyPayslipForNonAustralianResident(string name, decimal annualSalary, decimal monthlyPretax, decimal monthlyPostTax, decimal monthlyTax)
        {
            var employee = await _handler.Handle(new GetMonthlyPayslipByAnnualSalaryQuery.Query
            {
                Name = name,
                AnnualSalary = annualSalary,
                IsAustralianResident = false    
            }, CancellationToken.None);
            Assert.Equal(monthlyPretax, employee.MonthlyPreTaxSalary);
            Assert.Equal(monthlyTax, employee.MonthlyIncomeTax);
            Assert.Equal(monthlyPostTax, employee.MonthlyPostTaxSalary);
        }
    }
}
