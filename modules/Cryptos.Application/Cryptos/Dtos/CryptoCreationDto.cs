using Cryptos.Application.Services.Dtos;
using Cryptos.Application.Values.Dtos;

namespace Cryptos.Application.Cryptos.Dtos
{
    public class CryptoCreationDto : IEntityDto
    {
        public string Description { get; set; }

        //public IEnumerable<ValueCreationDto> Values { get; set; }
        public ValueCreationDto FirstValue { get; set; }

        public string Name { get; set; }
    }
}