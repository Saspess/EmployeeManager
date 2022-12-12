using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class DepartmentAddressConfiguration : IEntityTypeConfiguration<DepartmentAddress>
    {
        public void Configure(EntityTypeBuilder<DepartmentAddress> builder)
        {
            builder.HasKey(da => da.Id);
            builder.Property(da => da.Id).ValueGeneratedOnAdd();

            builder.Property(da => da.City).HasMaxLength(50).IsRequired();

            builder.Property(da => da.Street).HasMaxLength(50).IsRequired();

            builder.Property(da => da.HouseNumber).IsRequired();

            builder.Property(da => da.HouseCode).HasMaxLength(10);
        }
    }
}
