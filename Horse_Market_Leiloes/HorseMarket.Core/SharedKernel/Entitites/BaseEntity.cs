namespace HorseMarket.Core.SharedKernel.Entitites
{
    public abstract class BaseEntity<T>
    {
        protected BaseEntity()
        {
            Ativo = true;
        }

        public int Id { get; set; }
        public bool Ativo { get; set; }
    }
}
