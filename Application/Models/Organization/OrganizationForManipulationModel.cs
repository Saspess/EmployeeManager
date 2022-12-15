namespace Application.Models.Organization
{
    public abstract class OrganizationForManipulationModel
    {
        public int OrganizationDatasetId { get; set; }
        public string? Name { get; set; }

        public int OrganizationAddressId { get; set; }
        public int OrganizationContactId { get; set; }
        public string? DirectorName { get; set; }

        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public string? City { get; set; }
        public string? Street { get; set; }
        public int? HouseNumber { get; set; }
        public string? HouseCode { get; set; }
    }
}
