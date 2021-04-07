using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApp.Domain.Enum
{

    public enum PaymentStatusEnum
    {
        /// <summary>
        /// Pending
        /// </summary>
        Pending = 10,

        /// <summary>
        /// Processed
        /// </summary>
        Processed = 20,

        /// <summary>
        /// Failed
        /// </summary>
        Failed = 30,

    }

}
