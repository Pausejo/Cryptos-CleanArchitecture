using AutoMapper;
using Cryptos.Application.Services;
using Cryptos.Application.Values.Dtos;
using Cryptos.Core.Filtering;
using Cryptos.Domain.Values;
using System.Linq;

namespace Cryptos.Application.Values
{
    public class ValueService
        : ApplicationService<Value, long, IValueRepository, ValueCreationDto, ValueUpdateDto, ValueReadingDto>, IValueService
    {
        public ValueService(
            IValueRepository ValueRepository,
            IMapper mapper)
            : base(mapper,
                  ValueRepository)
        {
        }

        public IPagedEnumerable<ValueReadingDto> GetByCryptoId(long CryptoId, IPagingOptions pagingOptions = null)
        {
            var values = Repository.GetByCryptoId(CryptoId, pagingOptions);

            return new PagedEnumerable<ValueReadingDto>()
            {
                CurrentPage = values.CurrentPage,
                Items = values.Items.Select(Mapper.Map<ValueReadingDto>),
                TotalCount = values.TotalCount
            };
        }
    }
}