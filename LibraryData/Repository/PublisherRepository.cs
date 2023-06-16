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
    public class PublisherRepository : BaseRepository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(LibraryDbContext context) : base(context) { }
    }
}
