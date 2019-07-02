using System;

namespace HorseMarket.Core.Aggregate.Dtos
{
    public class LanceDto
    {
        public decimal Valor { get; set; }
        public int UserId { get; set; }
        public int LoteId { get; set; }
        public DateTime DataLance { get; set; }

        public LanceDto()
        {
            DataLance = DateTime.Now;
        }
    }
}
