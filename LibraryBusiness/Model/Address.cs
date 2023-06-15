namespace LibraryBusiness.Model
{
    public class Address : BaseModel
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public Guid? MemberId { get; set; }
        public Guid? LibraryId { get; set; }
        public Guid? PublisherId { get; set; }

        public Member Member { get; set; }
        public Library Library { get; set; }
        public Publisher Publisher { get; set; }
    }

}