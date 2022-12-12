using Application.ViewModels;

namespace Application.DTOs
{
    public class DepartmentsDto
    {
        public string Name { get; set; }
        public IEnumerable<DepartmentViewModel> Departments { get; set; }

        public DepartmentsDto(IEnumerable<DepartmentViewModel> organizations)
        {
            Departments = organizations;
        }
    }
}
