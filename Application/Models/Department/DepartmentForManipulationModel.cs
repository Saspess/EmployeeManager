namespace Application.Models.Department
{
    public abstract class DepartmentForManipulationModel
    {
        public string? OrganizationName { get; set; }
        public int OrganizationId { get; set; }
        public int DepartmentDatasetId { get; set; }
        public string? Name { get; set; } = null!;

        public string? City { get; set; }
        public string? Street { get; set; }
        public int? HouseNumber { get; set; }
        public string? HouseCode { get; set; }

        public int DepartmentAddressId { get; set; }
        public string? DirectorName { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
