using Cryptos.Core.Filtering;
using Cryptos.Domain.Entities;
using System.Collections.Generic;

namespace Cryptos.Domain.Cryptos
{
    public interface ICryptoRepository : IRepository<Crypto, long>
    {
        void BulkInsert(IEnumerable<Crypto> entity);

        IPagedEnumerable<Crypto> GetByFilters(IFilteringOptions filteringOptions);

        Crypto GetByName(string name);
    }
}