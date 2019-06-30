using HorseMarket.Core.Aggregate.Interfaces.Services;
using HorseMarket.Core.SharedKernel.Interfaces;
using HorseMarket.Core.SharedKernel.Service;

namespace HorseMarket.Application.Services
{
    public class LoteService : BaseService, ILoteService
    {
        public LoteService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
