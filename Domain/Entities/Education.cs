using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Education : BaseEntity
    {
        public string InstitutionName { get; set; } = null!;
        public int StartYear { get; set; }
        public int EndYear { get; set; }

        public ICollection<EmployeeDataset> EmployeeDatasets { get; set; } = null!;
    }
}
