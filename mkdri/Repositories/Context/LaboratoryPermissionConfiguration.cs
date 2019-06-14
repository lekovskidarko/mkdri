using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MKDRI.Models;

namespace MKDRI.Repositories.Context
{
    public class LaboratoryPermissionConfiguration : IEntityTypeConfiguration<LaboratoryPermission>
    {
        protected string Schema { get; }

        public LaboratoryPermissionConfiguration(string schema)
        {
            Schema = schema;
        }

        public virtual void Configure(EntityTypeBuilder<LaboratoryPermission> builder)
        {
            builder.ToTable("LaboratoryPermission", Schema);

            builder.HasKey(t => new { t.LaboratoryId, t.UserId });
        }
    }
}
