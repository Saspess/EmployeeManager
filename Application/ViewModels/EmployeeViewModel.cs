namespace Application.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string DepartmentName { get; set; } = null!;
        public string PositionName { get; set; } = null!;
        public int Salary { get; set; }
        public string Education { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Birthday { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
}
