namespace Cryptos.Application.Services.Dtos
{
    public abstract class EntityDto : IEntityDto
    {
    }

    public abstract class EntityDto<TPrimaryKey> : EntityDto, IEntityDto<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
    }
}