namespace Cryptos.Domain.Entities
{
    public abstract class Entity<TPrimaryKey> : EntityBase, IEntity<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
    }

    public abstract class EntityBase : IEntity
    {
    }
}