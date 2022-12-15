using Application.Interfaces.Repositories;
using Application.Interfaces.Contexts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(IApplicationDbContext appContext) : base(appContext)
        {
        }

        public override async Task<IEnumerable<Department>> GetAllAsync() =>
            await appContext.Set<Department>()
            .AsNoTracking()
            .Include(d => d.Organization)
            .Include(d => d.DepartmentDataset)
            .Include(d => d.DepartmentDataset.DepartmentAddress)
            .ToListAsync();

        public async Task<IEnumerable<Department>> GetByOrganizationIdAsync(int id) =>
            await appContext.Set<Department>()
            .AsNoTracking()
            .Include(d => d.Organization)
            .Include(d => d.DepartmentDataset)
            .Include(d => d.DepartmentDataset.DepartmentAddress)
            .Where(d => d.OrganizationId == id)
            .ToListAsync();

        public override async Task<Department?> GetByIdAsync(int id) =>
            await appContext.Set<Department>()
            .AsNoTracking()
            .Include(d => d.Organization)
            .Include(d => d.DepartmentDataset)
            .Include(d => d.DepartmentDataset.DepartmentAddress)
            .SingleOrDefaultAsync(d => d.Id == id);

        public async Task<Department?> GetByNameAsync(string name) =>
            await appContext.Set<Department>()
            .AsNoTracking()
            .Include(d => d.Organization)
            .Include(d => d.DepartmentDataset)
            .Include(d => d.DepartmentDataset.DepartmentAddress)
            .SingleOrDefaultAsync(d => d.Name == name);
    }
}
