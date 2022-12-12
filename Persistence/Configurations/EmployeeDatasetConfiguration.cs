using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class EmployeeDatasetConfiguration : IEntityTypeConfiguration<EmployeeDataset>
    {
        public void Configure(EntityTypeBuilder<EmployeeDataset> builder)
        {
            builder.HasKey(ed => ed.Id);
            builder.Property(ed => ed.Id).ValueGeneratedOnAdd();

            builder.HasIndex(ed => ed.EmployeeAddressId).IsUnique();
            builder.Property(ed => ed.EmployeeAddressId).IsRequired();

            builder.Property(ed => ed.EducationId).IsRequired();

            builder.Property(ed => ed.Birthday).HasMaxLength(100).IsRequired();

            builder.Property(ed => ed.PhoneNumber).HasMaxLength(50).IsRequired();
            builder.HasIndex(ed => ed.PhoneNumber).IsUnique();
        }
    }
}
