using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace ToDoApp.IoC
{
    public static class IoCConfigurations
    {
        public static void Configure(IServiceCollection services)
        {
            Configure(services, Data.IoC.Module.GetTypes());
            Configure(services, DomainServices.IoC.Module.GetTypes());
            Configure(services, AppServices.IoC.Module.GetTypes());
            Configure(services, Data.IoC.ReportModule.GetTypes());
            Configure(services, DomainServices.IoC.Module.GetTypes());
            Configure(services, AppServices.IoC.Module.GetTypes());
        }

        private static void Configure(IServiceCollection services, Dictionary<Type, Type> types)
        {
            foreach (var type in types)
            {
                services.AddScoped(type.Key, type.Value);
            }
        }


    }
}
