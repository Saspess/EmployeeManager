using Application.Interfaces.ServiceManager;
using Application.ServiceManagers;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.IoC
{
    public static class ServicesExtensions
    {
        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureFluentValidation(this IServiceCollection services) =>
            services.AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            });
    }
}
