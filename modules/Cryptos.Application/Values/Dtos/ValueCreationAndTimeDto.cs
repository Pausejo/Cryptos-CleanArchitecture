using System;

namespace Cryptos.Application.Values.Dtos
{
    public class ValueCreationAndTimeDto : ValueCreationDto
    {
        public DateTime CreationTime { get; set; }
    }
}