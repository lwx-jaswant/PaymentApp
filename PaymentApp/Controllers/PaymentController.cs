using System;
using System.Threading.Tasks;
using AutoMapper;
using PaymentApp.Domain.DTO.Payment;
using PaymentApp.Domain.DTO.Response;
using PaymentApp.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PaymentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : BaseController
    {

        public PaymentController(IAppPaymentService appPaymentService, IMapper mapper, ILoggerFactory loggerFactory) : base(loggerFactory)
        {
            this.appPaymentService = appPaymentService;
            this.mapper = mapper;
        }

        public IAppPaymentService appPaymentService { get; }
        public IMapper mapper { get; }


        [HttpPost("process")]
        public async Task<IActionResult> ProcessPayment([FromBody] PaymentRequestDto payment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseDto(ResponseStatusStringEnum.Error, "Bad Request"));
            }
            var result = await appPaymentService.MakePayment(payment);
            if (result)
                return Ok(result);
            return StatusCode(500);
        }


    }
}