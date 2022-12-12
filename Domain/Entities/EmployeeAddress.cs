using Domain.Entities.Common;

namespace Domain.Entities
{
    public class EmployeeAddress : BaseEntity
    {
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public int HouseNumber { get; set; }
        public int? FlatNumber { get; set; }
        public string? HouseCode { get; set; }

        public EmployeeDataset EmployeeDataset { get; set; } = null!;
    }
}
