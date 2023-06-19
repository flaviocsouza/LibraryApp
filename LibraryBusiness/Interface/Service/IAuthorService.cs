using LibraryBusiness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusiness.Interface.Service
{
    public interface IAuthorService
    {
        Task Insert(Author author);
        Task Update(Author author);
        Task Delete(Guid id);
    }
}
