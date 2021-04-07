using PaymentApp.Domain.Entity.Payment;
using PaymentApp.Domain.Interface;
using PaymentApp.Infrastructure.EntityFramework.Context;
using Microsoft.Extensions.Logging;

namespace PaymentApp.Infrastructure.Repository
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        private readonly DataContext context;

        public PaymentRepository(DataContext ctx) : base(ctx)
        {
            context = ctx;
        }

    }
}
