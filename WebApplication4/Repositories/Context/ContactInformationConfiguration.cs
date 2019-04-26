using MKDRI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MKDRI.Repositories.Context
{
    public class ContactInformationConfiguration : IEntityTypeConfiguration<ContactInformation>
    {
        protected string Schema { get; }

        public ContactInformationConfiguration(string schema)
        {
            Schema = schema;
        }

        public virtual void Configure(EntityTypeBuilder<ContactInformation> builder)
        {
            builder.ToTable("ContactInformation", Schema);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("integer").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Type).HasColumnName(@"Type").HasColumnType("integer").IsRequired();
            builder.Property(x => x.Content).HasColumnName(@"Content").HasColumnType("character varying").IsRequired().HasMaxLength(250);
        }
    }
}
