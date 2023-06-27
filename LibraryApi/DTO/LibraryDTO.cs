using System.ComponentModel.DataAnnotations;

namespace LibraryApi.DTO
{
    public class LibraryDTO
    {

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid AddressId { get; set; }
        public AddressDTO Address { get; set; }
    }
}