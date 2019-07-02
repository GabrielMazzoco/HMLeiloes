using System;

namespace HorseMarket.Core.Aggregate.Dtos
{
    public class CavaloDto
    {
        public string Nome { get; set; }
        public string Raca { get; set; }
        public string Genero { get; set; }
        public string Pelagem { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Estagio { get; set; }
        public int UserId { get; set; }
        public virtual string Mae { get; set; }
        public virtual string Pai { get; set; }
        public string FotoUrl { get; set; }
    }
}
