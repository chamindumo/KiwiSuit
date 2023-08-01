using AutoMapper;
using KiwiSuit.DTO;
using KiwiSuit.Models;

namespace KiwiSuit.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookDTO, Books>();
            CreateMap<Books, BookDTO>();
        }
    }
}
