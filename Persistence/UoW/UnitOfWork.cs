using Application.Interfaces.Contexts;
using Application.Interfaces.Repositories;
using Application.Interfaces.UoW;
using Persistence.Repositories;

namespace Persistence.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IApplicationDbContext _appContext;

        private IDepartmentAddressRepository _departmentAddressRepository;
        private IDepartmentDatasetRepository _departmentDatasetRepository;
        private IDepartmentRepository _departmentRepository;
        private IEducationRepository _educationRepository;
        private IEmployeeAddressRepository _employeeAddressRepository;
        private IEmployeeDatasetRepository _employeeDatasetRepository;
        private IEmployeeRepository _employeeRepository;
        private IOrganizationAddressRepository _organizationAddressRepository;
        private IOrganizationContactRepository _organizationContactRepository;
        private IOrganizationDatasetRepository _organizationDatasetRepository;
        private IOrganizationRepository _organizationRepository;
        private IPositionRepository _positionRepository;

        public UnitOfWork(IApplicationDbContext appContext)
        {
            _appContext = appContext ?? throw new ArgumentNullException(nameof(appContext));
        }

        public IDepartmentAddressRepository DepartmentAddressRepository
        {
            get
            {
                return _departmentAddressRepository ??= new DepartmentAddressRepository(_appContext); 
            }
        }

        public IDepartmentDatasetRepository DepartmentDatasetRepository
        {
            get
            {
                return _departmentDatasetRepository ??= new DepartmentDatasetRepository(_appContext);
            }
        }

        public IDepartmentRepository DepartmentRepository
        {
            get
            {
                return _departmentRepository ??= new DepartmentRepository(_appContext);
            }
        }

        public IEducationRepository EducationRepository
        {
            get 
            { 
                return _educationRepository ??= new EducationRepository(_appContext); 
            }
        }

        public IEmployeeAddressRepository EmployeeAddressRepository
        {
            get
            { 
                return _employeeAddressRepository ??= new EmployeeAddressRepository(_appContext); 
            }
        }

        public IEmployeeDatasetRepository EmployeeDatasetRepository
        {
            get 
            {
                return _employeeDatasetRepository ??= new EmployeeDatasetRepository(_appContext); 
            }
        }

        public IEmployeeRepository EmployeeRepository
        {
            get 
            { 
                return _employeeRepository ??= new EmployeeRepository(_appContext); 
            }
        }

        public IOrganizationAddressRepository OrganizationAddressRepository
        {
            get 
            { 
                return _organizationAddressRepository ??= new OrganizationAddressRepository(_appContext); 
            }
        }

        public IOrganizationContactRepository OrganizationContactRepository
        {
            get 
            { 
                return _organizationContactRepository ??= new OrganizationContactRepository(_appContext); 
            }
        }

        public IOrganizationDatasetRepository OrganizationDatasetRepository
        {
            get 
            { 
                return _organizationDatasetRepository ??= new OrganizationDatasetRepository(_appContext); 
            }
        }

        public IOrganizationRepository OrganizationRepository
        {
            get 
            { 
                return _organizationRepository ??= new OrganizationRepository(_appContext); 
            }
        }

        public IPositionRepository PositionRepository
        {
            get
            {
                return _positionRepository ??= new PositionRepository(_appContext);
            }
        }
    }
}
