using Domain.Entities.Common;

namespace Domain.Entities
{
    public class OrganizationContact : BaseEntity
    {
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public OrganizationDataset OrganizationDataset { get; set; } = null!;
    }
}
