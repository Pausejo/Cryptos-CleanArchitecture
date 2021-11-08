namespace Cryptos.Application.Services.Dtos
{
    public interface IEntityDto
    {
    }

    public interface IEntityDto<TPrimaryKey> : IEntityDto
    {
        TPrimaryKey Id { get; set; }
    }
}