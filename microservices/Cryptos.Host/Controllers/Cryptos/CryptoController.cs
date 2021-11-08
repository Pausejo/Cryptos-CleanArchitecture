using Cryptos.Application.Cryptos;
using Cryptos.Application.Cryptos.Dtos;
using Cryptos.Core.Filtering;
using Microsoft.AspNetCore.Mvc;

namespace Cryptos.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CryptoController : ControllerBase
    {
        private readonly ICryptoService _CryptoService;

        public CryptoController(ICryptoService CryptoService)
        {
            _CryptoService = CryptoService;
        }

        /// <summary>
        /// Deletes a Crypto by its primary key.
        /// </summary>
        /// <param name="id">Primary key of the Crypto to delete.</param>
        [HttpDelete]
        public void DeleteById(long id)
        {
            _CryptoService.DeleteById(id);
        }

        /// <summary>
        /// Gets all Cryptos mapped to ReadingDto.
        /// </summary>
        /// <param name="pagingOptions">Optional parameter to page the results.</param>
        /// <returns>The requested data, indicating paging-related info, if any.</returns>
        [HttpGet]
        public IPagedEnumerable<CryptoReadingDto> GetAll([FromQuery] PagingOptions pagingOptions = null)
        {
            var Cryptos = _CryptoService.GetAll(pagingOptions);

            return Cryptos;
        }

        /// <summary>
        /// Gets filtered Cryptos mapped to ReadingDto.
        /// </summary>
        /// <param name="filteringOptions">Optional parameter to filter and page the results.</param>
        /// <returns>The requested data, indicating paging-related info, if any.</returns>
        [HttpGet("by-filters")]
        public IPagedEnumerable<CryptoReadingDto> GetByFilters([FromQuery] FilteringOptions filteringOptions = null)
        {
            var Cryptos = _CryptoService.GetByFilters(filteringOptions);

            return Cryptos;
        }

        /// <summary>
        /// Gets a Crypto by its primary key mapped to ReadingDto.
        /// </summary>
        /// <param name="id">Primary key of the requested Crypto.</param>
        /// <returns>An instance of ReadingDto representing the requested Crypto or null if it does not exist.</returns>
        [HttpGet("by-id/{id}")]
        public CryptoReadingDto GetById(long id)
        {
            var Crypto = _CryptoService.GetById(id);

            return Crypto;
        }

        /// <summary>
        /// Creates and inserts a new Crypto.
        /// </summary>
        /// <param name="dto">Representation of the Crypto to create.</param>
        /// <returns>An instance of ReadingDto representing the newly created Crypto.</returns>
        [HttpPost]
        public CryptoReadingDto Insert(CryptoCreationDto dto)
        {
            var Crypto = _CryptoService.Insert(dto);

            return Crypto;
        }

        /// <summary>
        /// Updates an existing Crypto.
        /// </summary>
        /// <param name="dto">Representation of the Crypto to update.</param>
        /// <returns>An instance of ReadingDto representing the newly updated Crypto.</returns>
        [HttpPut]
        public CryptoReadingDto Update(CryptoUpdateDto dto)
        {
            return _CryptoService.Update(dto);
        }
    }
}