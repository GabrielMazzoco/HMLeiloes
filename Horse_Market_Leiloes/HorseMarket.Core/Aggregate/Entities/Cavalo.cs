using System;
using System.Collections.Generic;
using HorseMarket.Core.SharedKernel.Entitites;

namespace HorseMarket.Core.Aggregate.Entities
{
    public class Cavalo : BaseEntity<Cavalo>
    {
        public string Nome { get; set; }
        public string Raca { get; set; }
        public string Genero { get; set; }
        public string Pelagem { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Estagio { get; set; }
        public int MaeId { get; set; }
        public int PaiId { get; set; }
        public int HarasId { get; set; }
        public int LocalidadeId { get; set; }
        public int UserId { get; set; }

        public virtual Cavalo Mae { get; set; }
        public virtual Cavalo Pai { get; set; }
        public virtual Haras Haras { get; set; }
        public virtual Localidade Localidade { get; set; }
        public virtual User Dono { get; set; }
        public virtual Lote Lote { get; set; }
        public virtual ICollection<Foto> Fotos { get; set; }
    }
}
