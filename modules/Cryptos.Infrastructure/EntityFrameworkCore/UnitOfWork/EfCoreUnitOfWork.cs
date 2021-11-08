using Cryptos.Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Cryptos.Infrastructure.EntityFrameworkCore.UnitOfWork
{
    /// <summary>
    /// Unit of Work for Entity Framework Core.
    /// </summary>
    /// <typeparam name="TDbContext">DbContext enveloped by this Unit of Work.</typeparam>
    public class EfCoreUnitOfWork<TDbContext> : IUnitOfWork
        where TDbContext : DbContext
    {
        protected readonly TDbContext DbContext;

        public EfCoreUnitOfWork(TDbContext dbContext)
        {
            DbContext = dbContext;
        }

        /// <summary>
        /// Commits all pending changes to the database.
        /// </summary>
        public virtual void Commit()
        {
            DbContext.SaveChanges();
        }

        public virtual void Dispose()
        {
            DbContext.Dispose();
        }

        public virtual void Rollback()
        {
            DbContext.ChangeTracker.Entries().Where(x => x.State != EntityState.Added).ToList().ForEach(x => x.Reload());
            DbContext.ChangeTracker.Entries().Where(x => x.State == EntityState.Added).ToList().ForEach(x => x.State = EntityState.Detached);
        }
    }
}