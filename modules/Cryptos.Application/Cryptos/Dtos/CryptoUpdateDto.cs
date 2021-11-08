using Cryptos.Application.Services.Dtos;

namespace Cryptos.Application.Cryptos.Dtos
{
    public class CryptoUpdateDto : IEntityDto<long>
    {
        public string Description { get; set; }

        public long Id { get; set; }

        public string Name { get; set; }
    }
}