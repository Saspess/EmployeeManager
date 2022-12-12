using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class OrganizationDatasetConfiguration : IEntityTypeConfiguration<OrganizationDataset>
    {
        public void Configure(EntityTypeBuilder<OrganizationDataset> builder)
        {
            builder.HasKey(od => od.Id);
            builder.Property(od => od.Id).ValueGeneratedOnAdd();

            builder.HasIndex(od => od.OrganizationAddressId).IsUnique();
            builder.Property(od => od.OrganizationAddressId).IsRequired();

            builder.HasIndex(od => od.OrganizationContactId).IsUnique();
            builder.Property(od => od.OrganizationContactId).IsRequired();

            builder.HasIndex(od => od.DirectorName).IsUnique();
            builder.Property(od => od.DirectorName).HasMaxLength(100).IsRequired();
        }
    }
}
