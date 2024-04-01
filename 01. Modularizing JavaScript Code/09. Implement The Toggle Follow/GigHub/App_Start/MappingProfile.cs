using AutoMapper;
using GigHub.Dtos;
using GigHub.Models;

namespace GigHub
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Notification, NotificationDto>();
            Mapper.CreateMap<Gig, GigDto>();
            Mapper.CreateMap<ApplicationUser, UserDto>();
        }
    }
}