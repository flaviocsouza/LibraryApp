using AutoMapper;
using LibraryApi.ViewModel;
using LibraryBusiness.Model;

namespace LibraryApi.AutoMapper
{
    public class MapperConfig : Profile
    {

        public MapperConfig()
        {
            CreateMap<Address, AddressViewModel>().ReverseMap();
            CreateMap<Author, AuthorViewModel>().ReverseMap();
            CreateMap<Book, BookViewModel>().ReverseMap();
            CreateMap<Library, LibraryViewModel>().ReverseMap();
            CreateMap<Loan, LoanViewModel>().ReverseMap();
            CreateMap<Member, MemberViewModel>().ReverseMap();
            CreateMap<Publisher, PublisherViewModel>().ReverseMap();
        }
    }
}
