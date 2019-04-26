using MKDRI.Models;
using MKDRI.Models.UnitOfWork;
using MKDRI.Repositories.Context;
using System.Threading.Tasks;

namespace MKDRI.Repositories.UnitOfWork
{
    public class UnitOfWork
    {
        private BaseRepository<User> UsersRepo;
        public IBaseRepository<User> Users
        {
            get
            {
                if (UsersRepo == null)
                {
                    UsersRepo = new BaseRepository<User>(Context);
                }

                return UsersRepo;
            }
        }
        private BaseRepository<Laboratory> LaboratoryRepo;
        public IBaseRepository<Laboratory> Laboratories
        {
            get
            {
                if (LaboratoryRepo == null)
                {
                    LaboratoryRepo = new BaseRepository<Laboratory>(Context);
                }

                return LaboratoryRepo;
            }
        }

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
