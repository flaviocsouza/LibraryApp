using System.ComponentModel.DataAnnotations;

namespace LibraryApi.DTO
{
    public class AddressDTO
    {
        [Key]
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public Guid? MemberId { get; set; }
        public Guid? LibraryId { get; set; }
        public Guid? PublisherId { get; set; }

        public MemberDTO Member { get; set; }
        public LibraryDTO Library { get; set; }
        public PublisherDTO Publisher { get; set; }
    }

}