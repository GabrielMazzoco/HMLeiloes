using HorseMarket.Core.SharedKernel.Interfaces;

namespace HorseMarket.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void RollBack()
        {
            _context.Database.CurrentTransaction?.Rollback();

            Dispose();
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _context.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            if (_context.Database.CurrentTransaction != null)
                _context.Database.RollbackTransaction();
        }
    }
}
