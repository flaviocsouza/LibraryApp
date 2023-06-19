using LibraryBusiness.Interface.Service;
using LibraryBusiness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusiness.Service
{
    public class AuthorService : BaseService, IAuthorService
    {
        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Author author)
        {
            throw new NotImplementedException();
        }

        public Task Update(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
