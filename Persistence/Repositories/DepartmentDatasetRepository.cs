using Application.Interfaces.Repositories;
using Application.Interfaces.Contexts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class DepartmentDatasetRepository : GenericRepository<DepartmentDataset>, IDepartmentDatasetRepository
    {
        public DepartmentDatasetRepository(IApplicationDbContext appContext) : base(appContext)
        {
        }

        public override async Task<IEnumerable<DepartmentDataset>> GetAllAsync() =>
           await appContext.Set<DepartmentDataset>()
           .AsNoTracking()
           .Include(dd => dd.DepartmentAddress)
           .ToListAsync();

        public override async Task<DepartmentDataset?> GetByIdAsync(int id) =>
            await appContext.Set<DepartmentDataset>()
            .AsNoTracking()
            .Include(dd => dd.DepartmentAddress)
            .SingleOrDefaultAsync(dd => dd.Id == id);
    }
}
