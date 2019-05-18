namespace HorseMarket.Core.SharedKernel.Interfaces
{
    public interface IUnitOfWork
    {
        bool Commit();
        void Dispose();
        void RollBack();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
