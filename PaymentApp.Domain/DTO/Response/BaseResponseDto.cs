using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApp.Domain.DTO.Response
{

    public class ResponseDto
    {
        public ResponseDto()
        {

        }
        public ResponseDto(ResponseStatusStringEnum status, string message = "")
        {
            Status = status;
            Message = message;
        }
        public ResponseStatusStringEnum Status { get; set; }
        public string Message { get; set; }
    }

    public class ResponseStatusStringEnum
    {
        private ResponseStatusStringEnum(string value) { Value = value; }

        public string Value { get; set; }

        public static ResponseStatusStringEnum Success { get { return new ResponseStatusStringEnum("Success"); } }
        public static ResponseStatusStringEnum Error { get { return new ResponseStatusStringEnum("Error"); } }
    }
}
