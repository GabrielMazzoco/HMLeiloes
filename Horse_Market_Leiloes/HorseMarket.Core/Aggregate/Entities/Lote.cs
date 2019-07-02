using System.Collections.Generic;
using HorseMarket.Core.SharedKernel.Entitites;

namespace HorseMarket.Core.Aggregate.Entities
{
    public class Lote : BaseEntity<Lote>
    {
        public int CavaloId { get; set; }
        public decimal LanceMinimo { get; set; }
        public int Cobertura { get; set; }
        public int? LanceAtualId { get; set; }
        public decimal Incremento { get; set; }
        public int LeilaoId { get; set; }

        public virtual Cavalo Cavalo { get; set; }
        public virtual Leilao Leilao { get; set; }
        public virtual ICollection<Lance> Lances { get; set; }
    }
}
