using PaymentApp.Domain.Interface;
using PaymentApp.Domain.Interface.Services;
using PaymentApp.Infrastructure.EntityFramework.UnitOfWork;
using PaymentApp.Infrastructure.Repository;
using PaymentApp.Infrastructure.Service;
using PaymentApp.Util.Validation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PaymentApp.Service.Injection
{
    public class IocInfrastructure
    {
        public static void Set(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddTransient<ICheapPaymentGateway, CheapPaymentGateway>();
            services.AddTransient<IExpensivePaymentGateway, ExpensivePaymentGateway>();
            services.AddTransient<IPremiumPaymentGateway, PremiumPaymentGateway>();



            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<IServiceCollection>(services);


        }

    }
}
