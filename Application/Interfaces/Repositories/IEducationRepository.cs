using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IEducationRepository : IGenericRepository<Education>
    {
        Task<Education?> GetByNameAsync(string institutionName);
    }
}
