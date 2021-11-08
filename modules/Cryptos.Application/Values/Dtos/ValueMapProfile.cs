using AutoMapper;
using Cryptos.Domain.Values;

namespace Cryptos.Application.Values.Dtos
{
    public class ValueMapProfile : Profile
    {
        public ValueMapProfile()
        {
            CreateMap<ValueCreationDto, Value>();

            CreateMap<Value, ValueCreationDto>();

            CreateMap<Value, ValueUpdateDto>();

            CreateMap<Value, ValueReadingDto>()
            .ForMember(dst => dst.CryptoName, opt => opt.MapFrom(src => src.Crypto.Name));
        }
    }
}