using MKDRI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MKDRI.Repositories.Context
{
    public class LaboratoryConfiguration : IEntityTypeConfiguration<Laboratory>
    {
        protected string Schema { get; }

        public LaboratoryConfiguration(string schema)
        {
            Schema = schema;
        }

        public virtual void Configure(EntityTypeBuilder<Laboratory> builder)
        {
            builder.ToTable("Laboratory", Schema);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("integer").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Latitude).HasColumnName(@"Latitude").HasColumnType("real").IsRequired();
            builder.Property(x => x.Longitude).HasColumnName(@"Longitude").HasColumnType("real").IsRequired(); builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("character varying").IsRequired().HasMaxLength(200);
            builder.Property(x => x.City).HasConversion(new EnumToNumberConverter<Cities, int>()).HasColumnName(@"City").IsRequired();
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("text");
            builder.Property(x => x.Visits).HasColumnType("integer").HasDefaultValue(0);

            builder.HasMany(x => x.Equipment).WithOne(y => y.Laboratory).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Coordinator);
            builder.HasMany(x => x.ContactInformation).WithOne(y => y.Laboratory).HasForeignKey(x => x.LaboratoryId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Team).WithOne(y => y.Laboratory).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.ResearchServices).WithOne(y => y.Laboratory).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Permissions).WithOne(y => y.Laboratory).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
