using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PaymentApp.Domain.Entity.Payment
{
    public class Payment : BaseEntity
    {
        [Required]
        public string CreditCardNumber { get; set; }

        [Required]
        public string CardHolder { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        public string SecurityCode { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public int StateId { get; set; }
        public PaymentState State { get; set; }

    }
}
