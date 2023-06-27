
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace LibraryApi.DTO
{
    public class MemberDTO
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid AddressId { get; set; }
        public AddressDTO Address { get; set; }
        public IEnumerable<LoanDTO> LoanHistory { get; set; }
    }
}