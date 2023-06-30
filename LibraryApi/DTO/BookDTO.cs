using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace LibraryApi.DTO
{

    public class BookDTO
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public Guid AuthorId { get; set; }
        [Required]
        public Guid PublisherId { get; set; }

        public AuthorDTO Author { get; set; }
        public PublisherDTO Publisher { get; set; }

    }

   

}