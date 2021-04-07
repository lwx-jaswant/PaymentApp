using PaymentApp.Service.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PaymentApp.Service.Injection
{
    public class IocServices
    {
        public static void Set(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IAppPaymentService, AppPaymentService>();

        }
    }
}
