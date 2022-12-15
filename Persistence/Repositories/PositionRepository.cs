using Application.Interfaces.Contexts;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class PositionRepository : GenericRepository<Position>, IPositionRepository
    {
        public PositionRepository(IApplicationDbContext appContext) : base(appContext)
        {
        }

        public async Task<Position?> GetByNameAsync(string name) =>
            await appContext.Set<Position>()
            .AsNoTracking()
            .SingleOrDefaultAsync(p => p.Name == name);
    }
}
