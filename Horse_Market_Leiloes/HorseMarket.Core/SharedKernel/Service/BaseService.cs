using System.Collections.Generic;
using System.Linq;
using HorseMarket.Core.SharedKernel.Interfaces;

namespace HorseMarket.Core.SharedKernel.Service
{
    public class BaseService
    {
        protected readonly IUnitOfWork _unitOfWork;

        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected bool Commit()
        {
            return _unitOfWork.Commit();
        }

        protected bool IsNotNullOrEmpty<T>(IEnumerable<T> obj)
        {
            return obj.Any();
        }
    }
}
