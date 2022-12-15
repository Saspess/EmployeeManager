using Application.Interfaces.Contexts;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class OrganizationRepository : GenericRepository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(IApplicationDbContext appContext) : base(appContext)
        {
        }

        public override async Task<IEnumerable<Organization>> GetAllAsync() =>
            await appContext.Set<Organization>()
            .AsNoTracking()
            .Include(o => o.OrganizationDataset)
            .Include(o => o.OrganizationDataset.OrganizationAddress)
            .Include(o => o.OrganizationDataset.OrganizationContact)
            .ToListAsync();

        public override async Task<Organization?> GetByIdAsync(int id) =>
            await appContext.Set<Organization>()
            .AsNoTracking()
            .Include(o => o.OrganizationDataset)
            .Include(o => o.OrganizationDataset.OrganizationAddress)
            .Include(o => o.OrganizationDataset.OrganizationContact)
            .SingleOrDefaultAsync(d => d.Id == id);

        public async Task<Organization?> GetByNameAsync(string name) =>
            await appContext.Set<Organization>()
            .AsNoTracking()
            .Include(o => o.OrganizationDataset)
            .Include(o => o.OrganizationDataset.OrganizationAddress)
            .Include(o => o.OrganizationDataset.OrganizationContact)
            .SingleOrDefaultAsync(p => p.Name == name);
    }
}
