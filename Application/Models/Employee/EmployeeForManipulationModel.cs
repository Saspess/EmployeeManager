namespace Application.Models.Employee
{
    public abstract class EmployeeForManipulationModel
    {
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public int EmployeeDatasetId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? DepartmentName { get; set; }

        public int EmployeeAddressId { get; set; }
        public int EducationId { get; set; }
        public string? Birthday { get; set; }
        public string? PhoneNumber { get; set; }

        public string? City { get; set; }
        public string? Street { get; set; }
        public int? HouseNumber { get; set; }
        public int? FlatNumber { get; set; }
        public string? HouseCode { get; set; }

        public string? InstitutionName { get; set; }
        public int? StartYear { get; set; }
        public int? EndYear { get; set; }

        public string? PositionName { get; set; }
        public int? Salary { get; set; }
    }
}
