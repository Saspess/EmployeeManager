using Domain.Entities.Common;

namespace Domain.Entities
{
    public class DepartmentDataset : BaseEntity
    {
        public int DepartmentAddressId { get; set; }
        public string DirectorName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public Department Department { get; set; } = null!;
        public DepartmentAddress DepartmentAddress { get; set; } = null!;
    }
}
