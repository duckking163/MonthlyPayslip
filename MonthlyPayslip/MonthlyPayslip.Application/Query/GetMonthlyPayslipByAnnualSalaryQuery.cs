using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MonthlyPayslip.Domain;

namespace MonthlyPayslip.Application.Query
{
    public class GetMonthlyPayslipByAnnualSalaryQuery
    {
        public class Query:IRequest<Employee>
        {
            public string Name { get; set; }
            public decimal AnnualSalary{ get; set; }
        }

        public class Handler:IRequestHandler<Query, Employee>
        {
            public async Task<Employee> Handle(Query request, CancellationToken cancellationToken)
            {
                var employee = new Employee(request.Name, request.AnnualSalary);
                employee.PopulateMonthlySalary();
                return employee;
            }
        }
    }
}
