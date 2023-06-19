using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApi.ViewModel
{
    public class PublisherViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid AddressId { get; set; }
        public string Name { get; set; }

        public AddressViewModel Address { get; set; }
        public IEnumerable<BookViewModel> PublishedBooks { get; set; }
    }

}
