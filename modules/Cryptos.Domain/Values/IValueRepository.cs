using Cryptos.Core.Filtering;
using Cryptos.Domain.Entities;
using System;

namespace Cryptos.Domain.Values
{
    public interface IValueRepository : IRepository<Value, long>
    {
        Value GetByCreationTime(DateTime creationTime);

        IPagedEnumerable<Value> GetByCryptoId(long CryptoId, IPagingOptions pagingOptions = null);

        Value GetOrInsert(Value entity);
    }
}