using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApi.DTO
{
    public class AuthorDTO
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }     
        public string Nationality { get; set; }

        public IEnumerable<BookDTO> PublishedBooks { get; set; }
    }

}
