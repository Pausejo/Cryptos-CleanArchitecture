using Cryptos.Application.Services.Dtos;

namespace Cryptos.Application.Values.Dtos
{
    public class ValueUpdateDto : IEntityDto<long>
    {
        public decimal Amount { get; set; }

        //public DateTime CreationTime { get; set; }

        public long Id { get; set; }
    }
}