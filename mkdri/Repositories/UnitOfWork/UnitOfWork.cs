using Microsoft.EntityFrameworkCore;
using MKDRI.Models;
using MKDRI.Models.UnitOfWork;
using MKDRI.Repositories.Context;
using System.Threading.Tasks;

namespace MKDRI.Repositories.UnitOfWork
{
    public class UnitOfWork
    {
        public DbSet<User> UsersRepo { get; set; }
        public DbSet<User> Users { get { if (UsersRepo == null) { UsersRepo = Context.Set<User>(); } return UsersRepo; } }

        public DbSet<Laboratory> LaboratoriesRepo { get; set; }
        public DbSet<Laboratory> Laboratories { get { if (LaboratoriesRepo == null) { LaboratoriesRepo = Context.Set<Laboratory>(); } return LaboratoriesRepo; } }

        public DbSet<Organisation> OrganisationRepo { get; set; }
        public DbSet<Organisation> Organisation { get { if (OrganisationRepo == null) { OrganisationRepo = Context.Set<Organisation>(); } return OrganisationRepo; } }

        public DbSet<ContactInformation> ContactInformationRepo { get; set; }
        public DbSet<ContactInformation> ContactInformation { get { if (ContactInformationRepo == null) { ContactInformationRepo = Context.Set<ContactInformation>(); } return ContactInformationRepo; } }


        public IMKDRIContext Context { get; }
        public UnitOfWork(IMKDRIContext Context)
        {
            this.Context = Context;
        }

        public async Task<int> SaveAsync()
        {
            return await Context.SaveChangesAsync();
        }

    }
}
