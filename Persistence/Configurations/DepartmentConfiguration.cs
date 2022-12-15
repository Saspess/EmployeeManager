using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).ValueGeneratedOnAdd();

            builder.Property(d => d.OrganizationId).IsRequired();

            builder.HasIndex(d => d.DepartmentDatasetId).IsUnique();
            builder.Property(d => d.DepartmentDatasetId).IsRequired();

            builder.HasIndex(d => d.Name).IsUnique();
            builder.Property(d => d.Name).HasMaxLength(100).IsRequired();
        }
    }
}
