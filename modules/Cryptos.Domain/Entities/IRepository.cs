using Cryptos.Core.Filtering;

namespace Cryptos.Domain.Entities
{
    public interface IRepository
    {
    }

    public interface IRepository<TEntity, TPrimaryKey> : IRepository
        where TEntity : IEntity<TPrimaryKey>
    {
        void DeleteById(TPrimaryKey id);

        IPagedEnumerable<TEntity> GetAll(IPagingOptions pagingOptions = null);

        TEntity GetById(TPrimaryKey id);

        TEntity Insert(TEntity entity);

        TEntity Update(TEntity entity);
    }
}