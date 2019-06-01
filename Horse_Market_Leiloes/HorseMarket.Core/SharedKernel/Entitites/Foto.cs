using System;
using HorseMarket.Core.Aggregate;
using HorseMarket.Core.Aggregate.Entities;

namespace HorseMarket.Core.SharedKernel.Entitites
{
    public class Foto : BaseEntity<Foto>
    {
        public string Url { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        public int UserId { get; set; }
        public int CavaloId { get; set; }

        public virtual User User { get; set; }
        public virtual Cavalo Cavalo { get; set; }
        public virtual Leilao Leilao { get; set; }
    }
}
