using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace LibraryApi.ViewModel
{

    public class BookViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public Guid AuthorId { get; set; }
        public Guid PublisherId { get; set; }

        public AuthorViewModel Author { get; set; }
        public PublisherViewModel Publisher { get; set; }
        public IEnumerable<LoanViewModel> LoanHistory { get; set; }

    }

   

}