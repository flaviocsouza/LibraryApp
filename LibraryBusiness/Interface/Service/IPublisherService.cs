using LibraryBusiness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusiness.Interface.Service
{
    public interface IPublisherService
    {
        Task Insert(Publisher publisher);
        Task Update(Publisher publisher);
        Task Delete(Guid id);
    }
}
