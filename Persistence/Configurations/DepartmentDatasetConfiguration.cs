using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class DepartmentDatasetConfiguration : IEntityTypeConfiguration<DepartmentDataset>
    {
        public void Configure(EntityTypeBuilder<DepartmentDataset> builder)
        {
            builder.HasKey(dd => dd.Id);
            builder.Property(dd => dd.Id).ValueGeneratedOnAdd();

            builder.HasIndex(dd => dd.DepartmentAddressId).IsUnique();
            builder.Property(dd => dd.DepartmentAddressId).IsRequired();

            builder.HasIndex(dd => dd.DirectorName).IsUnique();
            builder.Property(dd => dd.DirectorName).HasMaxLength(100).IsRequired();

            builder.HasIndex(dd => dd.PhoneNumber).IsUnique();
            builder.Property(dd => dd.PhoneNumber).HasMaxLength(50).IsRequired();
        }
    }
}
