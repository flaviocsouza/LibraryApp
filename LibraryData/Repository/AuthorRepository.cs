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
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(LibraryDbContext context) : base(context) { }
    }
}
