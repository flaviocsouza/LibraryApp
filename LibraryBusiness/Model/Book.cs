using System.Collections;

namespace LibraryBusiness.Model
{

    public class Book: BaseModel
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public Guid AuthorId { get; set; }
        public Guid PublisherId { get; set; }

        public Author Author { get; set; }
        public Publisher Publisher { get; set; }
        public IEnumerable<Loan> LoanHistory { get; set; }

    }

   

}