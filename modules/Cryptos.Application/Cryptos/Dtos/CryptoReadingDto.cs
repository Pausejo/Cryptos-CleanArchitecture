using Cryptos.Application.Services.Dtos;

namespace Cryptos.Application.Cryptos.Dtos
{
    public class CryptoReadingDto : IEntityDto<long>
    {
        public string Description { get; set; }

        public long Id { get; set; }

        public decimal LastCryptoValue { get; set; }

        public string Name { get; set; }
    }
}