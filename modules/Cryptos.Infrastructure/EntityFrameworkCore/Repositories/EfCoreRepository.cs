using Cryptos.Core.Filtering;
using Cryptos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Cryptos.Infrastructure.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Entity Framework Core repository that provides basic generic CRUD methods for an entity.
    /// </summary>
    /// <typeparam name="TEntity">Represents an instance of type <see cref="IEntity{TPrimaryKey}"/>.</typeparam>
    /// <typeparam name="TPrimaryKey">Primary key of the entity.</typeparam>
    /// <typeparam name="TDbContext">DbContext where the entity is defined.</typeparam>
    public class EfCoreRepository<TEntity, TPrimaryKey, TDbContext> : IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        protected virtual DbSet<TEntity> DbSet
        {
            get
            {
                return _dbContext.Set<TEntity>();
            }
        }

        public EfCoreRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual void DeleteById(TPrimaryKey id)
        {
            var entity = GetById(id);

            if (entity != null)
            {
                Delete(entity);
            }
        }

        public virtual IPagedEnumerable<TEntity> GetAll(IPagingOptions pagingOptions = null)
        {
            return DbSet.PageResult(pagingOptions);
        }

        public virtual TEntity GetById(TPrimaryKey id)
        {
            return DbSet.Find(id);
        }

        public virtual TEntity Insert(TEntity entity)
        {
            var result = DbSet.Add(entity).Entity;

            _dbContext.SaveChanges();

            return result;
        }

        public virtual TEntity Update(TEntity entity)
        {
            AttachIfNot(entity);

            var result = DbSet.Update(entity).Entity;

            _dbContext.SaveChanges();

            return result;
        }

        protected virtual void AttachIfNot(TEntity entity)
        {
            var entry = _dbContext.ChangeTracker.Entries().FirstOrDefault(ent => ent.Entity == entity);

            if (entry != null)
            {
                return;
            }

            DbSet.Attach(entity);
        }

        protected void Delete(TEntity entity)
        {
            AttachIfNot(entity);

            DbSet.Remove(entity);

            _dbContext.SaveChanges();
        }
    }
}