using Cryptos.Application.Services;
using Cryptos.Application.Cryptos.Dtos;
using Cryptos.Core.Filtering;

namespace Cryptos.Application.Cryptos
{
    public interface ICryptoService : IApplicationService<long, CryptoCreationDto, CryptoUpdateDto, CryptoReadingDto>
    {
        public IPagedEnumerable<CryptoReadingDto> GetByFilters(IFilteringOptions filteringOptions = null);
    }
}