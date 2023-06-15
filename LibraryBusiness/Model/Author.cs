using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusiness.Model
{
    public class Author : BaseModel
    {
        public string Name { get; set; }     
        public string Nationality { get; set; }

        public IEnumerable<Book> PublishedBooks { get; set; }
    }

}
