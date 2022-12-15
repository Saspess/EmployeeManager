using Domain.Entities.Common;

namespace Domain.Entities
{
    public class OrganizationAddress : BaseEntity
    {
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public int HouseNumber { get; set; }
        public string? HouseCode { get; set; }

        public OrganizationDataset OrganizationDataset { get; set; } = null!;
    }
}
