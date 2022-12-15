using Application.Interfaces.Contexts;
using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Persistence.Repositories
{
    public class OrganizationAddressRepository : GenericRepository<OrganizationAddress>, IOrganizationAddressRepository
    {
        public OrganizationAddressRepository(IApplicationDbContext appContext) : base(appContext)
        {
        }
    }
}
