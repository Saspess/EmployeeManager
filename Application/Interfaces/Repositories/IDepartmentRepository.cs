using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        Task<IEnumerable<Department>> GetByOrganizationIdAsync(int id);
        Task<Department?> GetByNameAsync(string name);
    }
}
