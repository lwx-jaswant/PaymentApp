using AutoMapper;
using PaymentApp.Service.Convertions;
using PaymentApp.Service.Injection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Reflection;

namespace PaymentApp.Services
{
    public class AppServiceSetup
    {
        public void Set(IServiceCollection services, IConfiguration configuration)
        {

            IocInfrastructure.Set(services, configuration);

            IocServices.Set(services, configuration);


            AutoMapperSet(services);

            StartDomainHandlers(services);

        }

        void StartDomainHandlers(IServiceCollection services)
        {
            //DomainEvents.Init(services);
        }

        void AutoMapperSet(IServiceCollection services)
        {
            var profiles = new List<Assembly>
            {
                typeof(DomainEntityToDtoProfile).Assembly,
                typeof(DtoToDomainEntityProfile).Assembly
            };

            Mapper.Initialize(a => a.AddProfiles(profiles));
            services.AddSingleton(Mapper.Instance);
        }
    }
}
