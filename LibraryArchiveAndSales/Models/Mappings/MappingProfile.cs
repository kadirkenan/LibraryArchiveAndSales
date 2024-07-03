using AutoMapper;
using LibraryArchiveAndSales.Models.Dtos;
using LibraryArchiveAndSales.Models.Entities;

namespace LibraryArchiveAndSales.Models.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Note, NoteDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
