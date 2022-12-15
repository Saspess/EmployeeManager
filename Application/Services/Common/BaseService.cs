using Application.Interfaces.UoW;
using AutoMapper;

namespace Application.Services.Common
{
    public abstract class BaseService
    {
        protected readonly IMapper mapper;
        protected readonly IUnitOfWork unitOfWork;

        public BaseService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
    }
}
