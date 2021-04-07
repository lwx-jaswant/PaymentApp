using AutoMapper;
using PaymentApp.Domain.DTO.Payment;
using PaymentApp.Domain.Entity.Payment;

namespace PaymentApp.Service.Convertions
{
    public class DomainEntityToDtoProfile : Profile
    {
        public DomainEntityToDtoProfile()
        {
            CreateMap<Payment, PaymentRequestDto>().ReverseMap();
        }
    }
}
