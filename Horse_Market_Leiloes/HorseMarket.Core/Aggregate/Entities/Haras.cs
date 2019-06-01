using HorseMarket.Core.SharedKernel.Entitites;

namespace HorseMarket.Core.Aggregate.Entities
{
    public class Haras : BaseEntity<Haras>
    {
        public string Nome { get; set; }
        public string Dono { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int QtdCavalos { get; set; }
        public int LocalidadeId { get; set; }

        public virtual Localidade Localidade { get; set; }
    }
}
