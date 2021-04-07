using PaymentApp.Domain.DTO.Payment;
using PaymentApp.Domain.Interface.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Infrastructure.Service
{
    public class ExpensivePaymentGateway : IExpensivePaymentGateway
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
