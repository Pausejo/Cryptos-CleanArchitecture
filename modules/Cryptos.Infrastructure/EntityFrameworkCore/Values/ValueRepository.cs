using Cryptos.Core.Filtering;
using Cryptos.Domain.Values;
using Cryptos.Infrastructure.EntityFrameworkCore;
using Cryptos.Infrastructure.EntityFrameworkCore.Repositories;
using System;
using System.Linq;

namespace Cryptos.Infrastructure.EntityFrameworkCore.Cryptos
{
    public sealed class ValueRepository : EfCoreRepository<Value, long, ApplicationDbContext>, IValueRepository
    {
        public ValueRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public Value GetByCreationTime(DateTime creationTime)
        {
            var value = DbSet.FirstOrDefault(v => v.CreationTime == creationTime);

            return value;
        }

        public IPagedEnumerable<Value> GetByCryptoId(long CryptoId, IPagingOptions pagingOptions = null)
        {
            var values = DbSet.Where(v => v.CryptoId.Equals(CryptoId)).OrderByDescending(v => v.CreationTime);

            return values.PageResult(pagingOptions);
        }

        public Value GetOrInsert(Value entity)
        {
            var value = GetByCreationTime(entity.CreationTime);

            if (value == null)
            {
                value = InsertWithoutSaving(entity);
            }

            return value;
        }

        private Value InsertWithoutSaving(Value entity)
        {
            var result = DbSet.Add(entity).Entity;

            return result;
        }
    }
}