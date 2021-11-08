using AutoMapper;
using Cryptos.Application.Services;
using Cryptos.Application.Cryptos.Dtos;
using Cryptos.Core.Filtering;
using Cryptos.Domain.Cryptos;
using System.Linq;

namespace Cryptos.Application.Cryptos
{
    public class CryptoService
        : ApplicationService<Crypto, long, ICryptoRepository, CryptoCreationDto, CryptoUpdateDto, CryptoReadingDto>, ICryptoService
    {
        public CryptoService(
            ICryptoRepository CryptoRepository,
            IMapper mapper)
            : base(mapper, CryptoRepository)
        {
        }

        public IPagedEnumerable<CryptoReadingDto> GetByFilters(IFilteringOptions filteringOptions = null)
        {
            var Cryptos = Repository.GetByFilters(filteringOptions);

            return new PagedEnumerable<CryptoReadingDto>()
            {
                CurrentPage = Cryptos.CurrentPage,
                Items = Cryptos.Items.Select(Mapper.Map<CryptoReadingDto>),
                TotalCount = Cryptos.TotalCount
            };
        }
    }
}