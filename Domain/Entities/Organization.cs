using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Organization : BaseEntity
    {
        public int OrganizationDatasetId { get; set; }
        public string Name { get; set; } = null!;

        public OrganizationDataset OrganizationDataset { get; set; } = null!;
        public ICollection<Department> Departments { get; set; } = null!;
    }
}
