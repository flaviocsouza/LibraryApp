namespace LibraryBusiness.Model
{
    public class Library: BaseModel
    {
        public string Name { get; set; }

        public Guid AddressId { get; set; }
        public Address Address { get; set; }
    }
}