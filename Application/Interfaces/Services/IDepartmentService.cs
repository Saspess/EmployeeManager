using Application.Models.Department;
using Application.ViewModels;

namespace Application.Interfaces.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentViewModel>> GetAllAsync();
        Task<IEnumerable<DepartmentViewModel>> GetByOrganizationIdAsync(int id);
        Task<DepartmentViewModel> GetByIdAsync(int id);
        Task<DepartmentViewModel> GetByNameAsync(string name);
        Task CreateAsync(DepartmentForCreationModel departmentForCreationModel);
        Task UpdateAsync(DepartmentForUpdateModel departmentForUpdateModel);
        Task DeleteAsync(int id);

        Task<DepartmentForUpdateModel> GetDepartmentModelAsync(int id);
    }
}
