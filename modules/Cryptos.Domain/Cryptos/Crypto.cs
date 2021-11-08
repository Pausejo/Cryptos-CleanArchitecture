using Cryptos.Domain.Entities;
using Cryptos.Domain.Values;
using System.Collections.Generic;

namespace Cryptos.Domain.Cryptos
{
    public class Crypto : Entity<long>
    {
        public string Description { get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<Value> Values { get; set; }
    }
}