using System;
using System.Collections.Generic;
using HorseMarket.Core.Aggregate.Entities;
using HorseMarket.Core.SharedKernel.Entitites;

namespace HorseMarket.Core.Aggregate
{
    public class Leilao : BaseEntity<Leilao>
    {
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public string Nome { get; set; }
        public int FotoId { get; set; }
        public string Contato { get; set; }

        public virtual Foto Foto { get; set; }
        public virtual ICollection<Lote> Lotes { get; set; }
    }
}
