
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace LibraryApi.ViewModel
{
    public class MemberViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid AddressId { get; set; }
        public AddressViewModel Address { get; set; }
        public IEnumerable<LoanViewModel> LoanHistory { get; set; }
    }
}