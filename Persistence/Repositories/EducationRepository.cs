using Application.Interfaces.Contexts;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class EducationRepository : GenericRepository<Education>, IEducationRepository
    {
        public EducationRepository(IApplicationDbContext appContext) : base(appContext)
        {
        }

        public async Task<Education?> GetByNameAsync(string institutionName) =>
            await appContext.Set<Education>()
            .AsNoTracking()
            .SingleOrDefaultAsync(e => e.InstitutionName == institutionName);
    }
}
