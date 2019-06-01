namespace HorseMarket.Core.SharedKernel.Entitites
{
    public abstract class BaseEntity<T>
    {
        public int Id { get; set; }
        public bool Ativo { get; set; }
    }
}
