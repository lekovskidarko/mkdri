using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MKDRI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKDRI.Repositories.Context
{
    public class OrganisationConfiguration : IEntityTypeConfiguration<Organisation>
    {
        protected string Schema { get; }

        public OrganisationConfiguration(string schema)
        {
            Schema = schema;
        }

        public virtual void Configure(EntityTypeBuilder<Organisation> builder)
        {
            builder.ToTable("Organisation", Schema);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("integer").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("character varying").IsRequired().HasMaxLength(200);
            builder.Property(x => x.Image).HasColumnName(@"Image").HasColumnType("character varying").IsRequired();

            builder.HasOne(x => x.Director);
            builder.HasMany(x => x.ContactInformation).WithOne(y => y.Organisation).HasForeignKey(x => x.OrganisationId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}