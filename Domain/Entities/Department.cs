using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Department : BaseEntity
    {
        public int OrganizationId { get; set; }
        public int DepartmentDatasetId { get; set; }
        public string Name { get; set; } = null!;

        public Organization Organization { get; set; } = null!;
        public DepartmentDataset DepartmentDataset { get; set; } = null!;
        public ICollection<Employee> Employees { get; set; } = null!;
    }
}
