using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace MonthlyPayslip.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(assembly);
            return services;
        }
    }
}
