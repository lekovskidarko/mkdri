using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MKDRI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKDRI.Repositories.Context
{

    public class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
    {
        protected string Schema { get; }

        public EquipmentConfiguration(string schema)
        {
            Schema = schema;
        }

        public virtual void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.ToTable("Equipment", Schema);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("integer").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Manufacturer).HasColumnName(@"Manufacturer").HasColumnType("character varying").HasMaxLength(200);
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("character varying").HasMaxLength(200).IsRequired();
            builder.Property(x => x.Year).HasColumnName(@"Year").HasColumnType("integer");
            builder.Property(x => x.CatalogName).HasColumnName(@"CatalogName").HasColumnType("character varying").HasMaxLength(200);
            builder.Property(x => x.Datasheet).HasColumnName(@"DataSheet").HasColumnType("character varying").HasMaxLength(300);
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("text");

            builder.HasOne(x => x.Laboratory).WithMany(y => y.Equipment);
        }
    }
}
