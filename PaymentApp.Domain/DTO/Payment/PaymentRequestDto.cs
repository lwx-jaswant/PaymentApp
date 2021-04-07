using PaymentApp.Util.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace PaymentApp.Domain.DTO.Payment
{
    public class PaymentRequestDto
    {
        [Required]
        [RegularExpression(@"^(\d{4}-){3}\d{4}$|^(\d{4} ){3}\d{4}$|^\d{16}$")]
        public string CreditCardNumber { get; set; }

        [Required]
        public string CardHolder { get; set; }

        [Required]
        [AfterToday]
        public DateTime ExpirationDate { get; set; }

        [ExactLength(3)]
        public string SecurityCode { get; set; }
        
        [Required]
        [RegularExpression(@"^[0-9]\d*$")]
        public decimal Amount { get; set; }

    }

   
}
