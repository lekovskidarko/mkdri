using JetBrains.Annotations;
using MKDRI.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MKDRI.Models;

namespace MKDRI.Repositories.Context
{
    public class MKDRIContext : DbContext, IMKDRIContext
    {
        public IConfiguration Configuration { get; }

        public MKDRIContext (DbContextOptions<MKDRIContext > options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseLazyLoadingProxies().UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));

        public override EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException(nameof(entity));
            }

            return base.Entry(entity);
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        public override DbSet<TEntity> Set<TEntity>()
        {
            return base.Set<TEntity>();
        }

        public override EntityEntry Update(object entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException(nameof(entity));
            }

            return base.Update(entity);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            string schema = "main";
            modelBuilder.ApplyConfiguration(new UserConfiguration(schema));
            modelBuilder.ApplyConfiguration(new ContactInformationConfiguration(schema));
            modelBuilder.ApplyConfiguration(new ResearchServiceConfiguration(schema));
            modelBuilder.ApplyConfiguration(new ResearchServicePersonConfiguration(schema));
            modelBuilder.ApplyConfiguration(new LaboratoryConfiguration(schema));
            modelBuilder.ApplyConfiguration(new LaboratoryTeamConfiguration(schema));
            modelBuilder.ApplyConfiguration(new EquipmentConfiguration(schema));
            modelBuilder.ApplyConfiguration(new OrganisationConfiguration(schema));
            modelBuilder.ApplyConfiguration(new LaboratoryPermissionConfiguration(schema));
            modelBuilder.ApplyConfiguration(new OrganisationPermissionConfiguration(schema));
        }
    }
}
