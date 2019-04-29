using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MKDRI.Models;

namespace MKDRI.Repositories.Context
{
    public class LaboratoryTeamConfiguration : IEntityTypeConfiguration<LaboratoryTeam>
    {
        protected string Schema { get; }

        public LaboratoryTeamConfiguration(string schema)
        {
            Schema = schema;
        }

        public virtual void Configure(EntityTypeBuilder<LaboratoryTeam> builder)
        {
            builder.ToTable("LaboratoryTeam", Schema);

            builder.HasKey(t => new { t.LaboratoryId, t.UserId });
        }
    }
}
