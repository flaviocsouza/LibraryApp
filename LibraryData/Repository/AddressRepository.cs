using LibraryBusiness.Interface.Repository;
using LibraryBusiness.Model;
using LibraryData.LibraryContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData.Repository
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(LibraryDbContext context) : base(context) { }
    }
}
