namespace Cryptos.Domain.Entities
{
    public interface IEntity
    {
    }

    public interface IEntity<TPrimaryKey> : IEntity
    {
        /// <summary>
        /// Represents the primary key of the entity.
        /// </summary>
        TPrimaryKey Id { get; set; }
    }
}