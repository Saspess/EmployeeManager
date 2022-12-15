using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class EducationConfiguration : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.HasIndex(e => e.InstitutionName).IsUnique();
            builder.Property(e => e.InstitutionName).HasMaxLength(100).IsRequired();

            builder.Property(e => e.StartYear).IsRequired();

            builder.Property(e => e.EndYear).IsRequired();
        }
    }
}
