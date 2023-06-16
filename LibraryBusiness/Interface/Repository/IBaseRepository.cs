using LibraryBusiness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusiness.Interface.Repository
{
    public interface IBaseRepository<Entity>: IDisposable where Entity : BaseModel
    {
        Task<IEnumerable<Entity>> GetAll();
        Task<Entity?> GetById(Guid id);
        Task Insert (Entity entity);
        Task Update (Entity entity);
        Task Delete (Guid id);
        Task<int> SaveChanges();


    }
}
