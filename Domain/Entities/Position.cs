using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Position : BaseEntity
    {
        public string Name { get; set; } = null!;
        public int Salary { get; set; }

        public ICollection<Employee> Employees { get; set; } = null!;
    }
}
