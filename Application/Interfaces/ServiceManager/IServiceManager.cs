

using Application.Interfaces.Services;

namespace Application.Interfaces.ServiceManager
{
    public interface IServiceManager
    {
        IOrganizationService OrganizationService { get; }
        IDepartmentService DepartmentService { get; }
        IEmployeeService EmployeeService { get; }
    }
}
