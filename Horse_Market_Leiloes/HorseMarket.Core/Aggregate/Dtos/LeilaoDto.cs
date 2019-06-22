using System;

namespace HorseMarket.Core.Aggregate.Dtos
{
    public class LeilaoDto
    {
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public string Nome { get; set; }
        public string FotoUrl { get; set; }
        public string Contato { get; set; }
        public string Descricao { get; set; }
    }
}
