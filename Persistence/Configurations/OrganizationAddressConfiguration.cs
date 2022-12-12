using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Configurations
{
    public class OrganizationAddressConfiguration : IEntityTypeConfiguration<OrganizationAddress>
    {
        public void Configure(EntityTypeBuilder<OrganizationAddress> builder)
        {
            builder.HasKey(oa => oa.Id);
            builder.Property(oa => oa.Id).ValueGeneratedOnAdd();

            builder.Property(oa => oa.City).HasMaxLength(50).IsRequired();

            builder.Property(oa => oa.Street).HasMaxLength(50).IsRequired();

            builder.Property(oa => oa.HouseNumber).IsRequired();

            builder.Property(oa => oa.HouseCode).HasMaxLength(10);
        }
    }
}
