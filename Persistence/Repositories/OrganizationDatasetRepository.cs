using Application.Interfaces.Contexts;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class OrganizationDatasetRepository : GenericRepository<OrganizationDataset>, IOrganizationDatasetRepository
    {
        public OrganizationDatasetRepository(IApplicationDbContext appContext) : base(appContext)
        {
        }

        public override async Task<IEnumerable<OrganizationDataset>> GetAllAsync() =>
            await appContext.Set<OrganizationDataset>()
            .AsNoTracking()
            .Include(od => od.OrganizationAddress)
            .Include(od => od.OrganizationContact)
            .ToListAsync();

        public override async Task<OrganizationDataset?> GetByIdAsync(int id) =>
            await appContext.Set<OrganizationDataset>()
            .AsNoTracking()
            .Include(od => od.OrganizationAddress)
            .Include(od => od.OrganizationContact)
            .SingleOrDefaultAsync(od => od.Id == id);
    }
}
