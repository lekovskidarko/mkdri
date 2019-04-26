using MKDRI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MKDRI.Repositories.Context
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        protected string Schema { get; }

        public UserConfiguration(string schema)
        {
            Schema = schema;
        }
        
        public virtual void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", Schema);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("integer").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.FirstName).HasColumnName(@"FirstName").HasColumnType("character varying").IsRequired();
            builder.Property(x => x.LastName).HasColumnName(@"LastName").HasColumnType("character varying").IsRequired();
            builder.Property(x => x.Email).HasColumnName(@"Email").HasColumnType("character varying").IsRequired();
            builder.Property(x => x.Password).HasColumnName(@"Password").HasColumnType("character varying").IsRequired();
            builder.Property(x => x.CreatedOn).HasColumnName(@"CreatedOn").HasColumnType("timestamp without time zone").IsRequired();
            builder.Property(x => x.DeletedOn).HasColumnName(@"DeletedOn").HasColumnType("timestamp without time zone").HasDefaultValue(null);

            
        }
    }
}
