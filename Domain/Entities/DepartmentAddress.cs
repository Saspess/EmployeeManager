using Domain.Entities.Common;

namespace Domain.Entities
{
    public class DepartmentAddress : BaseEntity
    {
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public int HouseNumber { get; set; }
        public string? HouseCode { get; set; }

        public DepartmentDataset DepartmentDataset { get; set; } = null!;
    }
}
