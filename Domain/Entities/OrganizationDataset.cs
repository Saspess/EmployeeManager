using Domain.Entities.Common;

namespace Domain.Entities
{
    public class OrganizationDataset : BaseEntity
    {
        public int OrganizationAddressId { get; set; }
        public int OrganizationContactId { get; set; }
        public string DirectorName { get; set; } = null!;

        public Organization Organization { get; set; } = null!;
        public OrganizationAddress OrganizationAddress { get; set; } = null!;
        public OrganizationContact OrganizationContact { get; set; } = null!;
    }
}
