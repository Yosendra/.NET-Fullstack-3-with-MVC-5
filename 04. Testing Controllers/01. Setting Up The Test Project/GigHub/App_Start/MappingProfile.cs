using AutoMapper;
using GigHub.Core.Models;
using GigHub.Core.Dtos;

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