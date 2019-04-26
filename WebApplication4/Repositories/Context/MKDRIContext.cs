using JetBrains.Annotations;
using MKDRI.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;
using MKDRI.Repositories.Context;

namespace MKDRI.Repositories.Context
{
    public class MKDRIContext : DbContext, IMKDRIContext
    {
        public MKDRIContext (DbContextOptions<MKDRIContext > options) : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=Asus;Username=Asus;Password=admin");

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
            modelBuilder.ApplyConfiguration(new LaboratoryConfiguration(schema));
            modelBuilder.ApplyConfiguration(new EquipmentConfiguration(schema));
        }
    }
}
