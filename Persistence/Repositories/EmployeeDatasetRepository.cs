using Application.Interfaces.Repositories;
using Application.Interfaces.Contexts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class EmployeeDatasetRepository : GenericRepository<EmployeeDataset>, IEmployeeDatasetRepository
    {
        public EmployeeDatasetRepository(IApplicationDbContext appContext) : base(appContext)
        {
        }

        public override async Task<IEnumerable<EmployeeDataset>> GetAllAsync() =>
            await appContext.Set<EmployeeDataset>()
            .AsNoTracking()
            .Include(ed => ed.EmployeeAddress)
            .Include(ed => ed.Education)
            .ToListAsync();

        public override async Task<EmployeeDataset?> GetByIdAsync(int id) =>
            await appContext.Set<EmployeeDataset>()
            .AsNoTracking()
            .Include(ed => ed.EmployeeAddress)
            .Include(ed => ed.Education)
            .SingleOrDefaultAsync(ed => ed.Id == id);
    }
}
