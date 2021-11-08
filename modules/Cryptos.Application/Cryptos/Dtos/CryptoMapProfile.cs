using AutoMapper;
using Cryptos.Application.Values.Dtos;
using Cryptos.Domain.Cryptos;
using System.Collections.Generic;
using System.Linq;

namespace Cryptos.Application.Cryptos.Dtos
{
    public class CryptoMapProfile : Profile
    {
        public CryptoMapProfile()
        {
            CreateMap<CryptoCreationDto, Crypto>()
                .ForMember(dst => dst.Values,
                 opt =>
                 {
                     opt.PreCondition(src => src.FirstValue != null);
                     opt.MapFrom(src => new List<ValueCreationDto>()
                    {
                        src.FirstValue
                    });
                 });

            CreateMap<CryptoUpdateDto, Crypto>();

            CreateMap<Crypto, CryptoReadingDto>()
                .ForMember(dst => dst.LastCryptoValue,
                    opt => opt.MapFrom(src => src.Values.OrderByDescending(v => v.CreationTime).FirstOrDefault().Amount));
        }
    }
}

//?? new ValueCreationDto()
//{
//    Amount = 0
//}