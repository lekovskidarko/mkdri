using MKDRI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MKDRI.Repositories.Context
{
    public class ResearchServiceConfiguration : IEntityTypeConfiguration<ResearchService>
    {
        protected string Schema { get; }

        public ResearchServiceConfiguration(string schema)
        {
            Schema = schema;
        }

        public virtual void Configure(EntityTypeBuilder<ResearchService> builder)
        {
            builder.ToTable("ResearchService", Schema);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("integer").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("character varying").IsRequired().HasMaxLength(200);
            builder.Property(x => x.Type).HasColumnName(@"Type").HasColumnType("integer").IsRequired();
        }
    }
}
