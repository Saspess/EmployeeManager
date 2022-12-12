using Application.ViewModels;

namespace Application.DTOs
{
    public class EmployeesDto
    {

        public string Name { get; set; }
        public IEnumerable<EmployeeViewModel> Employees { get; set; }

        public EmployeesDto(IEnumerable<EmployeeViewModel> employees)
        {
            Employees = employees;
        }
    }
}
