using AutoMapper;
using Moq;
using PaymentApp.Domain.Entity.Payment;
using PaymentApp.Domain.Interface;
using PaymentApp.Domain.Interface.Services;
using PaymentApp.Service;
using PaymentApp.Service.Interface;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PaymentApp.test
{
    public class AppPaymentService
    {

        [Fact]
        public async Task MakePayment_ReturnsTrue_ValidDto()
        {
            //Arrange
            var dto = new Domain.DTO.Payment.PaymentRequestDto { Amount = 1000, CardHolder = "Test User", CreditCardNumber = "1111 2222 3333 4444", ExpirationDate = DateTime.Now.AddDays(1), SecurityCode = "111" };

            var unitOfWork = new Mock<IUnitOfWork>();
            var mapper = new Mock<IMapper>();

            mapper.Setup(c => c.Map<Payment>(dto)).Returns(new Payment { Amount = 1000, CardHolder = "Test User", CreditCardNumber = "1111 2222 3333 4444", ExpirationDate = DateTime.Now.AddDays(1), SecurityCode = "111" });
            var paymentRepository = new Mock<IPaymentRepository>();
            var cheapPaymentGateway = new Mock<ICheapPaymentGateway>();
            cheapPaymentGateway.Setup(c => c.Charge(dto)).ReturnsAsync( dto.Amount<=20);

            var expensivePaymentGateway = new Mock<IExpensivePaymentGateway>();
            expensivePaymentGateway.Setup(c => c.Charge(dto)).ReturnsAsync(dto.Amount <= 500);

            var premiumPaymentGateway = new Mock<IPremiumPaymentGateway>();
            premiumPaymentGateway.Setup(c => c.Charge(dto)).ReturnsAsync(true);

            var paymentService = new Mock<Service.AppPaymentService>(unitOfWork.Object, mapper.Object, paymentRepository.Object, cheapPaymentGateway.Object, expensivePaymentGateway.Object, premiumPaymentGateway.Object).Object;

            //Act
            var isSuccess = await paymentService.MakePayment(dto);

            //Assert
            Assert.True(isSuccess);
        }
    }
}
