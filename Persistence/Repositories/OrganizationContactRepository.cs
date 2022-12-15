using Application.Interfaces.Contexts;
using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Persistence.Repositories
{
    public class OrganizationContactRepository : GenericRepository<OrganizationContact>, IOrganizationContactRepository
    {
        public OrganizationContactRepository(IApplicationDbContext appContext) : base(appContext)
        {
        }
    }
}
