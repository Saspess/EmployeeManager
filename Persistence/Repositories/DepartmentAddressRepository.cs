using Application.Interfaces.Contexts;
using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Persistence.Repositories
{
    public class DepartmentAddressRepository : GenericRepository<DepartmentAddress>, IDepartmentAddressRepository
    {
        public DepartmentAddressRepository(IApplicationDbContext appContext) : base(appContext)
        {
        }
    }
}
