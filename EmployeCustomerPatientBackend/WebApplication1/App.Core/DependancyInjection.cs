using App.Core.CustomerCommand;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App.Core
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining<AddCustomerCommand>();
                //cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            return services;
           
        }
    }
}

