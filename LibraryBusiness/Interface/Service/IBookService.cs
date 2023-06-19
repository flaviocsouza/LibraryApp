using LibraryBusiness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusiness.Interface.Service
{
    public interface IBookService
    {
        Task Insert(Book book);
        Task Update(Book book);
        Task Delete(Guid id);
    }
}

