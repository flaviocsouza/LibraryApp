using System;

namespace LibraryBusiness.Model
{
    public class Loan: BaseModel
    {
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public Guid BookId { get; set; }
        public Guid MemberId { get; set; }


        public Book Book { get; set; }
        public Member Member { get; set; }

    }
}