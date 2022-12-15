using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class EmployeeAddressConfiguration : IEntityTypeConfiguration<EmployeeAddress>
    {
        public void Configure(EntityTypeBuilder<EmployeeAddress> builder)
        {
            builder.HasKey(ea => ea.Id);
            builder.Property(ea => ea.Id).ValueGeneratedOnAdd();

            builder.Property(ea => ea.City).HasMaxLength(50).IsRequired();

            builder.Property(ea => ea.Street).HasMaxLength(50).IsRequired();

            builder.Property(ea => ea.HouseNumber).IsRequired();

            builder.Property(ea => ea.HouseCode).HasMaxLength(10);
        }
    }
}
