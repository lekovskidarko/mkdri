using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MKDRI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKDRI.Repositories.Context
{
    public class ResearchServicePersonConfiguration : IEntityTypeConfiguration<ResearchServicePerson>
    {
        protected string Schema { get; }

        public ResearchServicePersonConfiguration(string schema)
        {
            Schema = schema;
        }

        public virtual void Configure(EntityTypeBuilder<ResearchServicePerson> builder)
        {
            builder.ToTable("ResearchServicePerson", Schema);

            builder.HasKey(t => new { t.ResearchServiceId, t.UserId });
        }
    }
}
