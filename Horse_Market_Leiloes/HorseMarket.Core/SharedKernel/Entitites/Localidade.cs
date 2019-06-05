using HorseMarket.Core.Aggregate.Entities;

namespace HorseMarket.Core.SharedKernel.Entitites
{
    public class Localidade : BaseEntity<Localidade>
    {
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairo { get; set; }
        public int UserId { get; set; }
        public int HarasId { get; set; }
        public int CavaloId { get; set; }

        public virtual Haras Haras { get; set; }
        public virtual User User { get; set; }
        public virtual Cavalo Cavalo { get; set; }
    }
}
