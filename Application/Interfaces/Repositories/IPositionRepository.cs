using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IPositionRepository : IGenericRepository<Position>
    {
        Task<Position?> GetByNameAsync(string name);
    }
}
