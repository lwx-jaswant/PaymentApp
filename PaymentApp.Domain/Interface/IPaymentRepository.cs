using PaymentApp.Domain.DTO.Payment;
using PaymentApp.Domain.Entity.Payment;
using System.Threading.Tasks;

namespace PaymentApp.Domain.Interface
{
    public interface IPaymentRepository : IRepository<Payment>
    {
    }
}
