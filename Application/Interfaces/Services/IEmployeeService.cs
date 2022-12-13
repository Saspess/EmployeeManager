using Application.Models.Employee;
using Application.ViewModels;

namespace Application.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeViewModel>> GetAllAsync();
        Task<IEnumerable<EmployeeViewModel>> GetByDepartmentIdAsync(int id);
        Task CreateAsync(EmployeeForCreationModel employeeForCreationModel);
        Task UpdateAsync(EmployeeForUpdateModel employeeForUpdateModel);
        Task DeleteAsync(int id);
        Task<EmployeeForUpdateModel> GetEmployeeModelAsync(int id);
    }
}
