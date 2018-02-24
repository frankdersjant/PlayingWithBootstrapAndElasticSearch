
using AutoMapper;
using DataLayer;
using Domain.DomainModels.Persons;
using PlayingWithBootstrap.ViewModels;

namespace PlayingWithBootstrap.App_Start
{
    public static class MappingConfig
    {
        public static void RegisterMaps()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Person, PersonVM>().ForMember(dest => dest.FullName, fn => fn.MapFrom(src => (src.FirstName + " " + src.LastName)));
                config.CreateMap<ApplicationUser, UserViewModel>();
            });
        }
    }
}