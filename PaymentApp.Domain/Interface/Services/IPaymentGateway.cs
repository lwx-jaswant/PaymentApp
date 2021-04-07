using PaymentApp.Domain.DTO.Payment;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Domain.Interface.Services
{
    public interface IPaymentGateway
    {
        Task<bool> Charge(PaymentRequestDto dto);
    }
}
