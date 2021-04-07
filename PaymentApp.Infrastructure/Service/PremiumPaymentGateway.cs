using PaymentApp.Domain.DTO.Payment;
using PaymentApp.Domain.Interface.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Infrastructure.Service
{
    public class PremiumPaymentGateway : IPremiumPaymentGateway
    {
        public Task<bool> Charge(PaymentRequestDto dto)
        {
            var attempt = 1;
            var isSuccess = false;

            while (attempt <= 3 && !isSuccess)
            {
                try
                {
                    // Send external payment request here
                    isSuccess = true;
                }
                catch (System.Exception)
                {
                    attempt++;
                }
            }

            return Task.FromResult(isSuccess);
        }
    }
}
