using AutoMapper;
using LibraryApi.DTO;
using LibraryBusiness.Model;

namespace LibraryApi.AutoMapper
{
    public class MapperConfig : Profile
    {

        public MapperConfig()
        {
            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<Author, AuthorDTO>().ReverseMap();
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Library, LibraryDTO>().ReverseMap();
            CreateMap<Loan, LoanDTO>().ReverseMap();
            CreateMap<Member, MemberDTO>().ReverseMap();
            CreateMap<Publisher, PublisherDTO>().ReverseMap();
        }
    }
}
