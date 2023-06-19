using System.ComponentModel.DataAnnotations;

namespace LibraryApi.ViewModel
{
    public class LibraryViewModel
    {

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid AddressId { get; set; }
        public AddressViewModel Address { get; set; }
    }
}