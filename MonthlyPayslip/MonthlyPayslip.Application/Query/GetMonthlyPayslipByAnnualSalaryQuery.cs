using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MonthlyPayslip.Domain;
using MonthlyPayslip.Application.Model;

namespace MonthlyPayslip.Application.Query
{
    public class GetMonthlyPayslipByAnnualSalaryQuery
    {
        public class Query:IRequest<EmployeeDto>
        {
            public string Name { get; set; }
            public decimal AnnualSalary{ get; set; }
            public bool IsAustralianResident{ get; set; }

        }

        public class Handler:IRequestHandler<Query, EmployeeDto>
        {
            public Handler()
            {
                
            }
            public async Task<EmployeeDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var employee = new Employee(request.Name, request.AnnualSalary,request.IsAustralianResident);
                employee.PopulateMonthlySalary();
                return new EmployeeDto { 
                    EmployeeName=employee.EmployeeName,
                    AnnualSalary = employee.AnnualSalary,
                    MonthlyPreTaxSalary = employee.MonthlyPreTaxSalary,
                    MonthlyIncomeTax = employee.MonthlyIncomeTax,
                    MonthlyPostTaxSalary = employee.MonthlyPostTaxSalary
                };
            }
        }
    }
}
