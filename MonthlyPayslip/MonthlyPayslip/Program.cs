using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Hosting;
using MonthlyPayslip.Application;
using MonthlyPayslip.Application.Query;

namespace MonthlyPayslip
{
    class Program
    {
        private static readonly IMediator _mediator;

        static async Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            Console.WriteLine("Please type input string.");
            var inputString = Console.ReadLine();
            var inputStringList = inputString.Split('"');
            try
            {
                var employee = await  _mediator.Send(new GetMonthlyPayslipByAnnualSalaryQuery.Query
                {
                    Name = inputStringList[1],
                    AnnualSalary = Decimal.Parse(inputStringList[2])
                });
                Console.WriteLine($"Monthly Payslip for: \"{employee.EmployeeName}\"");
                Console.WriteLine($"Gross Monthly Income: \"{employee.MonthlyPreTaxSalary:C}\"");
                Console.WriteLine($"Monthly Income Tax: \"{employee.MonthlyIncomeTax:C}\"");
                Console.WriteLine($"Net Monthly Income: \"{employee.MonthlyPostTaxSalary:C}\"");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error engaged during the process. Here is the error message:");
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddApplication());
    }
}
