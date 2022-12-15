using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class OrganizationContactConfiguration : IEntityTypeConfiguration<OrganizationContact>
    {
        public void Configure(EntityTypeBuilder<OrganizationContact> builder)
        {
            builder.HasKey(oc => oc.Id);
            builder.Property(oc => oc.Id).ValueGeneratedOnAdd();

            builder.HasIndex(oc => oc.Email).IsUnique();
            builder.Property(oc => oc.Email).HasMaxLength(255).IsRequired();

            builder.HasIndex(oc => oc.PhoneNumber).IsUnique();
            builder.Property(oc => oc.PhoneNumber).HasMaxLength(20).IsRequired();
        }
    }
}
