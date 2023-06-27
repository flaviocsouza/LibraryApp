using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApi.DTO
{
    public class PublisherDTO
    {
        [Key]
        public Guid Id { get; set; }
        public Guid AddressId { get; set; }
        public string Name { get; set; }

        public AddressDTO Address { get; set; }
        public IEnumerable<BookDTO> PublishedBooks { get; set; }
    }

}
