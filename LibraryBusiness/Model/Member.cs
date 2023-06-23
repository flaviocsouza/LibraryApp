
using System.Collections; 

namespace LibraryBusiness.Model
{
    public class Member: BaseModel
    {
        public string Name { get; set; }
        public string Document { get; set; }

        public Guid AddressId { get; set; }
        public Address Address { get; set; }
        public IEnumerable<Loan> LoanHistory { get; set; }
    }
}