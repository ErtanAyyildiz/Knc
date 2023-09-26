using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knc.Business.IoC
{
    public static class ModuleInjector
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            //services.AddTransient<IValidator<Project>, ProjectValidator>();

            //services.AddScoped<IAppUserService, AppUserService>();
            //services.AddScoped<ITrainStationService, TrainStationService>();
            //services.AddScoped<ITrainJourneyService, TrainJourneyService>();

            //services.AddScoped<IValidator<AppUser>, UserValidator>();
            //services.AddScoped<IValidator<UserRole>, UserRoleValidator>();

            return services;
        }
    }
}
