using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PaymentApp.Util.Validation
{
    public class AfterTodayAttribute : ValidationAttribute
    {

        public AfterTodayAttribute()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime)
            {
                return ((DateTime)value).CompareTo(DateTime.Now) > 0
                         ? ValidationResult.Success
                         : new ValidationResult($"Date should be after now");
            }
            return new ValidationResult("This validator can only be applied to DateTime");

        }

    }


    public class ExactLengthAttribute : ValidationAttribute
    {
        private int length;
        public ExactLengthAttribute(int length)
        {
            this.length = length;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is String)
            {
                return (length == ((String)value).Length)
                         ? ValidationResult.Success
                         : new ValidationResult($"String length should be {length}");
            }
            return new ValidationResult("This validator can only be applied to String");

        }


    }
}
