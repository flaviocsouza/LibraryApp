using LibraryBusiness.Interface.Service;
using LibraryBusiness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusiness.Service
{
    public class LibraryService : BaseService, ILibraryService
    {
        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Library library)
        {
            throw new NotImplementedException();
        }

        public Task Update(Library library)
        {
            throw new NotImplementedException();
        }
    }
}
