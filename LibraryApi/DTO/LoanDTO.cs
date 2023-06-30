using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryApi.DTO
{
    public class LoanDTO
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime LoanDate { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        public DateTime ReturnDate { get; set; }

        [Required]
        public Guid BookId { get; set; }
        [Required]
        public Guid MemberId { get; set; }

        public BookDTO Book { get; set; }
        public MemberDTO Member { get; set; }

    }
}