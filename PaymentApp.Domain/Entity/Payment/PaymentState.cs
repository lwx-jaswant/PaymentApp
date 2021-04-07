using PaymentApp.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PaymentApp.Domain.Entity.Payment
{
    public class PaymentState
    {
        [Key]
        public int Id { get; set; }
        public PaymentStatusEnum Status { get; set; }
    }
}
