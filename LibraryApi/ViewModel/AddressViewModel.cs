using System.ComponentModel.DataAnnotations;

namespace LibraryApi.ViewModel
{
    public class AddressViewModel
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

        public MemberViewModel Member { get; set; }
        public LibraryViewModel Library { get; set; }
        public PublisherViewModel Publisher { get; set; }
    }

}