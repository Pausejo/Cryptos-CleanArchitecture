using Cryptos.Application.Values;
using Cryptos.Application.Values.Dtos;
using Cryptos.Core.Filtering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cryptos.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValueController : ControllerBase
    {
        private readonly ILogger<ValueController> _logger;

        private readonly IValueService _valueService;

        public ValueController(ILogger<ValueController> logger, IValueService valueService)
        {
            _logger = logger;
            _valueService = valueService;
        }

        /// <summary>
        /// Gets filtered values by a CryptoId mapped to ReadingDto.
        /// </summary>
        /// <param name="CryptoId">Primary key of the Crypto to filter.</param>
        /// <param name="pagingOptions">Optional parameter to filter and page the results.</param>
        /// <returns>The requested data, indicating paging-related info, if any.</returns>
        [HttpGet("by-Crypto-id/{CryptoId}")]
        public IPagedEnumerable<ValueReadingDto> GetByCryptoId(long CryptoId, [FromQuery] PagingOptions pagingOptions = null)
        {
            var values = _valueService.GetByCryptoId(CryptoId, pagingOptions);

            return values;
        }

        /// <summary>
        /// Creates and inserts a new Crypto value.
        /// </summary>
        /// <param name="dto">Representation of the value to create.</param>
        /// <returns>An instance of ReadingDto representing the newly created value.</returns>
        [HttpPost]
        public ValueReadingDto Insert(ValueCreationDto dto)
        {
            var value = _valueService.Insert(dto);

            return value;
        }
    }
}