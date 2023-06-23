using AutoMapper;
using Session2.AppDbContext;
using Session2.Models;

namespace Session2.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Users, User>().ReverseMap();
        }
    }
}
