using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HR.LeaveManagement.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());

            return serviceCollection;
        }
    }
}