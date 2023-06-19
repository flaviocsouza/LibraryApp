using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryApi.ViewModel
{
    public class LoanViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public Guid BookId { get; set; }
        public Guid MemberId { get; set; }


        public BookViewModel Book { get; set; }
        public MemberViewModel Member { get; set; }

    }
}