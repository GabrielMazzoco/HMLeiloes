using System;
using HorseMarket.Core.SharedKernel.Entitites;

namespace HorseMarket.Core.Aggregate.Entities
{
    public class Lance : BaseEntity<Lance>
    {
        public decimal Valor { get; set; }
        public int UserId { get; set; }
        public int LoteId { get; set; }
        public DateTime DataLance { get; set; }

        public virtual User User { get; set; }
        public virtual Lote Lote { get; set; }
    }
}
