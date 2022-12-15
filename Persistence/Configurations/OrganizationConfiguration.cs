using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();

            builder.HasIndex(o => o.OrganizationDatasetId).IsUnique();
            builder.Property(o => o.OrganizationDatasetId).IsRequired();

            builder.HasIndex(o => o.Name).IsUnique();
            builder.Property(o => o.Name).HasMaxLength(255).IsRequired();
        }
    }
}
