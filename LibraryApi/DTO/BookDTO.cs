using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace LibraryApi.DTO
{

    public class BookDTO
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public Guid AuthorId { get; set; }
        public Guid PublisherId { get; set; }

        public AuthorDTO Author { get; set; }
        public PublisherDTO Publisher { get; set; }
        public IEnumerable<LoanDTO> LoanHistory { get; set; }

    }

   

}