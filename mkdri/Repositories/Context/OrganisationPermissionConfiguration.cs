using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MKDRI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKDRI.Repositories.Context
{
    public class OrganisationPermissionConfiguration : IEntityTypeConfiguration<OrganisationPermission>
    {
        protected string Schema { get; }

        public OrganisationPermissionConfiguration(string schema)
        {
            Schema = schema;
        }

        public virtual void Configure(EntityTypeBuilder<OrganisationPermission> builder)
        {
            builder.ToTable("OrganisationPermission", Schema);

            builder.HasKey(t => new { t.OrganisationId, t.UserId });
        }
    }
}
