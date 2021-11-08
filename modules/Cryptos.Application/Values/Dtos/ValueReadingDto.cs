using Cryptos.Application.Services.Dtos;
using System;

namespace Cryptos.Application.Values.Dtos
{
    public class ValueReadingDto : IEntityDto<long>
    {
        public decimal Amount { get; set; }

        public DateTime CreationTime { get; set; }

        public long CryptoId { get; set; }

        public string CryptoName { get; set; }

        public long Id { get; set; }
    }
}