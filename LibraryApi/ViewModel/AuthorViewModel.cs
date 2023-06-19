using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApi.ViewModel
{
    public class AuthorViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }     
        public string Nationality { get; set; }

        public IEnumerable<BookViewModel> PublishedBooks { get; set; }
    }

}
