namespace HorseMarket.Core.Aggregate.Dtos
{
    public class LoteRegisterDto
    {
        public int Id { get; set; }
        public decimal LanceMinimo { get; set; }
        public int Cobertura { get; set; }
        public decimal Incremento { get; set; }
        public int LeilaoId { get; set; }
        public decimal ValorAtual { get; set; }

        public CavaloDto Cavalo { get; set; }
    }
}
