using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusiness.Model
{
    public class Publisher: BaseModel
    {
        public Guid AddressId { get; set; }
        public string Name { get; set; }

        public Address Address { get; set; }
        public IEnumerable<Book> PublishedBooks { get; set; }
    }

}
