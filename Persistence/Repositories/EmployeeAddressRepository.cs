using Application.Interfaces.Contexts;
using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Persistence.Repositories
{
    public class EmployeeAddressRepository : GenericRepository<EmployeeAddress>, IEmployeeAddressRepository
    {
        public EmployeeAddressRepository(IApplicationDbContext appcontext) : base(appcontext)
        {
        }
    }
}
