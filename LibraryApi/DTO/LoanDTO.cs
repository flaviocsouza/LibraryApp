using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryApi.DTO
{
    public class LoanDTO
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public Guid BookId { get; set; }
        public Guid MemberId { get; set; }


        public BookDTO Book { get; set; }
        public MemberDTO Member { get; set; }

    }
}