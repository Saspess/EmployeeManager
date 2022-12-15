using Application.Interfaces.ServiceManager;
using Application.Interfaces.Services;
using Application.Interfaces.UoW;
using Application.Services;
using AutoMapper;

namespace Application.ServiceManagers
{
    public class ServiceManager : IServiceManager
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        private IOrganizationService _organizationService;
        private IDepartmentService _departmentService;
        private IEmployeeService _employeeService;

        public ServiceManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); 
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public IOrganizationService OrganizationService
        {
            get
            {
                return _organizationService ??= new OrganizationService(_mapper, _unitOfWork);
            }
        }

        public IDepartmentService DepartmentService
        {
            get
            {
                return _departmentService ??= new DepartmentService(_mapper, _unitOfWork);
            }
        }

        public IEmployeeService EmployeeService
        {
            get
            {
                return _employeeService ??= new EmployeeService(_mapper, _unitOfWork);
            }
        }
    }
}
