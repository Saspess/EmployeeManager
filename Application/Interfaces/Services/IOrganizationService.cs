using Application.Models.Organization;
using Application.ViewModels;

namespace Application.Interfaces.Services
{
    public interface IOrganizationService
    {
        Task<IEnumerable<OrganizationViewModel>> GetAllAsync();
        Task<OrganizationViewModel> GetByIdAsync(int id);
        Task<OrganizationViewModel> GetByNameAsync(string name);
        Task CreateAsync(OrganizationForCreationModel organizationForCreationModel);
        Task UpdateAsync(OrganizationForUpdateModel organizationForUpdateModel);
        Task DeleteAsync(int id);

        Task<OrganizationForUpdateModel> GetOrganizationModelAsync(int id);
    }
}
