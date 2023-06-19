using LibraryBusiness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusiness.Interface.Service
{
    public interface ILibraryService
    { 
        Task Insert(Library library);
        Task Update(Library library);
        Task Delete(Guid id);
    }
}

