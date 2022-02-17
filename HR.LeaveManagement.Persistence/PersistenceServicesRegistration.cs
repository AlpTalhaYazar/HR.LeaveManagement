using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HR.LeaveManagement.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HRLeaveManagementDbContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("HRLeaveManagementConnectionString"),
                    contextOptionsBuilder =>
                    {
                        contextOptionsBuilder.MigrationsAssembly(Assembly
                            .GetAssembly(typeof(HRLeaveManagementDbContext)).GetName().Name);
                    });
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();

            return services;
        }
    }
}
