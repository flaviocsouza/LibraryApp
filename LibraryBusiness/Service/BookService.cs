using LibraryBusiness.Interface.Service;
using LibraryBusiness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusiness.Service
{
    public class BookService : BaseService, IBookService
    {
        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Book book)
        {
            throw new NotImplementedException();
        }

        public Task Update(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
