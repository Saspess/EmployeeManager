using Domain.Entities.Common;

namespace Domain.Entities
{
    public class EmployeeDataset : BaseEntity
    {
        public int EmployeeAddressId { get; set; }
        public int EducationId { get; set; }
        public string Birthday { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public Employee Employee { get; set; } = null!;
        public Education Education { get; set; } = null!;
        public EmployeeAddress EmployeeAddress { get; set; } = null!;
    }
}
