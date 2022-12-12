using Application.Interfaces.Contexts;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IApplicationDbContext appContext) : base(appContext)
        {
        }

        public override async Task<IEnumerable<Employee>> GetAllAsync() =>
            await appContext.Set<Employee>()
            .AsNoTracking()
            .Include(e => e.Department)
            .Include(e => e.Position)
            .Include(e => e.EmployeeDataset)
            .Include(e => e.EmployeeDataset.EmployeeAddress)
            .Include(e => e.EmployeeDataset.Education)
            .ToListAsync();

        public async Task<IEnumerable<Employee>> GetByDepartmentIdAsync(int id) =>
            await appContext.Set<Employee>()
            .AsNoTracking()
            .Include(e => e.Department)
            .Include(e => e.Position)
            .Include(e => e.EmployeeDataset)
            .Include(e => e.EmployeeDataset.EmployeeAddress)
            .Include(e => e.EmployeeDataset.Education)
            .Where(e => e.DepartmentId == id)
            .ToListAsync();

        public override async Task<Employee?> GetByIdAsync(int id) =>
            await appContext.Set<Employee>()
            .AsNoTracking()
            .Include(e => e.Department)
            .Include(e => e.Position)
            .Include(e => e.EmployeeDataset)
            .Include(e => e.EmployeeDataset.EmployeeAddress)
            .Include(e => e.EmployeeDataset.Education)
            .SingleOrDefaultAsync(e => e.Id == id);

        public async Task<Employee?> GetByNameAsync(string lastName) =>
            await appContext.Set<Employee>()
            .AsNoTracking()
            .Include(e => e.Department)
            .Include(e => e.Position)
            .Include(e => e.EmployeeDataset)
            .Include(e => e.EmployeeDataset.EmployeeAddress)
            .Include(e => e.EmployeeDataset.Education)
            .SingleOrDefaultAsync( e => e.LastName == lastName);
    }
}
