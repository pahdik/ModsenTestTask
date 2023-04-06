using AutoMapper;
using DAL.Models;
using Library.BLL.DTO;
using Library.DAL.Models;

namespace Library.BLL.Profiles
{
    public class AppMappingProfile:Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Book, BookUpdateDTO>().ReverseMap();
            CreateMap<Book, BookAddDTO>().ReverseMap();
            CreateMap<User,RegisterDTO>().ReverseMap();
        }
    }
}
