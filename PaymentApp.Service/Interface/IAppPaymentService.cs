using PaymentApp.Domain.DTO.Payment;
using System.Threading.Tasks;

namespace PaymentApp.Service.Interface
{
    public interface IAppPaymentService
    {
        ValueTask<bool> MakePayment(PaymentRequestDto paymentDto);
    }

    
}
