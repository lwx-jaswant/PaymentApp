using AutoMapper;
using PaymentApp.Domain.DTO.Payment;
using PaymentApp.Domain.Entity.Payment;
using PaymentApp.Domain.Interface;
using PaymentApp.Domain.Interface.Services;
using PaymentApp.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace PaymentApp.Service
{
    public class AppPaymentService : IAppPaymentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IPaymentRepository paymentRepository;
        public ICheapPaymentGateway cheapPaymentGateway { get; }
        public IExpensivePaymentGateway expensivePaymentGateway { get; }
        public IPremiumPaymentGateway premiumPaymentGateway { get; }

        public AppPaymentService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IPaymentRepository paymentRepository,
            ICheapPaymentGateway cheapPaymentGateway,
            IExpensivePaymentGateway expensivePaymentGateway,
            IPremiumPaymentGateway premiumPaymentGateway
            )
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.paymentRepository = paymentRepository;
            this.cheapPaymentGateway = cheapPaymentGateway;
            this.expensivePaymentGateway = expensivePaymentGateway;
            this.premiumPaymentGateway = premiumPaymentGateway;
        }

        public async ValueTask<bool> MakePayment(PaymentRequestDto dto)
        {
            if (dto == null)
                return false;

            var payment = mapper.Map<Payment>(dto);
            payment.State = new PaymentState { Status = Domain.Enum.PaymentStatusEnum.Pending};

            this.paymentRepository.Add(payment);

            await unitOfWork.Complete();

            var paymentResult = await Change(dto);

            if (paymentResult)
            {
                payment.State.Status = Domain.Enum.PaymentStatusEnum.Processed;
            }
            else
            {
                payment.State.Status = Domain.Enum.PaymentStatusEnum.Failed;
            }

            await unitOfWork.Complete();

            return paymentResult;
        }


        private async Task<bool> Change(PaymentRequestDto dto)
        {
            var result = false;
            if (dto.Amount <= 20)
            {
                result = await cheapPaymentGateway.Charge(dto);
            }
            else if (dto.Amount < 500)
            {
                result = await cheapPaymentGateway.Charge(dto); ;
                if (!result)
                    result = await cheapPaymentGateway.Charge(dto); 
            }
            else
            {
                result = await premiumPaymentGateway.Charge(dto);
            }

            return result;
        }

    }
}
