using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetByDepartmentIdAsync(int id);
        Task<Employee?> GetByNameAsync(string name);
    }
}
