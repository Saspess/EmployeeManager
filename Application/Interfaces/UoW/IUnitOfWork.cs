using Application.Interfaces.Repositories;

namespace Application.Interfaces.UoW
{
    public interface IUnitOfWork
    {
        IDepartmentRepository DepartmentRepository { get; }
        IDepartmentAddressRepository DepartmentAddressRepository { get; }
        IDepartmentDatasetRepository DepartmentDatasetRepository { get; }
        IEducationRepository EducationRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        IEmployeeAddressRepository EmployeeAddressRepository { get; }
        IEmployeeDatasetRepository EmployeeDatasetRepository { get; }
        IOrganizationRepository OrganizationRepository { get; }
        IOrganizationAddressRepository OrganizationAddressRepository { get; }
        IOrganizationContactRepository OrganizationContactRepository { get; }
        IOrganizationDatasetRepository OrganizationDatasetRepository { get; }
        IPositionRepository PositionRepository { get; }
    }
}
