using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApp.Util.Infrastructure
{
    public class AppException : Exception
    {
        public AppException(string message)
            : base(message)
        {
        }
    }
}
