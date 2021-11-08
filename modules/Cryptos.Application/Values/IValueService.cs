using Cryptos.Application.Services;
using Cryptos.Application.Values.Dtos;
using Cryptos.Core.Filtering;

namespace Cryptos.Application.Values
{
    public interface IValueService : IApplicationService<long, ValueCreationDto, ValueUpdateDto, ValueReadingDto>
    {
        IPagedEnumerable<ValueReadingDto> GetByCryptoId(long CryptoId, IPagingOptions pagingOptions = null);
    }
}