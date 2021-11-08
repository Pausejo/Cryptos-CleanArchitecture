using Cryptos.Application.Services.Dtos;

namespace Cryptos.Application.Values.Dtos
{
    public class ValueCreationDto : IEntityDto
    {
        public decimal Amount { get; set; }

        //public DateTime CreationTime { get; set; }

        public long CryptoId { get; set; }
    }
}