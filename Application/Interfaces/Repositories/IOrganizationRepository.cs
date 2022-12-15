using Domain.Entities;
namespace Application.Interfaces.Repositories
{
    public interface IOrganizationRepository : IGenericRepository<Organization>
    {
        Task<Organization?> GetByNameAsync(string name);
    }
}
