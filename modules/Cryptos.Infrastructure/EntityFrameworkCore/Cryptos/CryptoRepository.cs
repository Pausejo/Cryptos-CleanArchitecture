using Cryptos.Core.Filtering;
using Cryptos.Domain.Cryptos;
using Cryptos.Infrastructure.EntityFrameworkCore;
using Cryptos.Infrastructure.EntityFrameworkCore.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Cryptos.Infrastructure.EntityFrameworkCore.Cryptos
{
    public sealed class CryptoRepository : EfCoreRepository<Crypto, long, ApplicationDbContext>, ICryptoRepository
    {
        public CryptoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public void BulkInsert(IEnumerable<Crypto> entity)
        {
            DbSet.AddRange(entity);
        }

        public IPagedEnumerable<Crypto> GetByFilters(IFilteringOptions filteringOptions)
        {
            var Cryptos = DbSet.AsQueryable();

            if (filteringOptions.Keyword != null && filteringOptions.Keyword != "")
            {
                Cryptos = Cryptos.Where(f =>
                    f.Name.Contains(filteringOptions.Keyword) ||
                    f.Description.Contains(filteringOptions.Keyword));
            }

            return Cryptos.PageResult(filteringOptions);
        }

        public Crypto GetByName(string name)
        {
            var value = DbSet.FirstOrDefault(v => v.Name == name);

            return value;
        }
    }
}