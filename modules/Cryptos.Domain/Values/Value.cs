using Cryptos.Domain.Entities;
using Cryptos.Domain.Cryptos;
using System;

namespace Cryptos.Domain.Values
{
    public class Value : Entity<long>
    {
        public decimal Amount { get; set; }

        public DateTime CreationTime { get; set; }

        public virtual Crypto Crypto { get; set; }

        public long CryptoId { get; set; }

        public Value()
        {
            CreationTime = DateTime.UtcNow;
        }
    }
}