using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKDRI.Models.UnitOfWork
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> All();

        Task<T> GetByIdAsync(int id);

        void Insert(T newEntry);
      
        void Delete(int id);

        void Update(T entry);
        
        void Dispose();

        void SaveAsync();
    }
}
