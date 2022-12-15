using Application.Interfaces.Contexts;
using Application.Interfaces.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.UoW;

namespace Persistence.IoC
{
    public static class ServicesExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<ApplicationDbContext>(opts =>
            opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

        public static void ConfigureDbContext(this IServiceCollection services) =>
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

        public static void ConfigureUnitOfWork(this IServiceCollection services) =>
            services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
