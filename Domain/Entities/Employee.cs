using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Employee : BaseEntity
    {
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public int EmployeeDatasetId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public Position Position { get; set; } = null!;
        public EmployeeDataset EmployeeDataset { get; set; } = null!;
        public Department Department { get; set; } = null!;
    }
}
