using PaymentApp.Domain.DTO.Payment;
using PaymentApp.Domain.Interface.Services;
using System.Threading.Tasks;

namespace PaymentApp.Infrastructure.Service
{
    public class CheapPaymentGateway : ICheapPaymentGateway
    {
        public Task<bool> Charge(PaymentRequestDto dto)
        {
            try
            {
                // Send external payment request here
            }
            catch (System.Exception)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);

        }
    }
}