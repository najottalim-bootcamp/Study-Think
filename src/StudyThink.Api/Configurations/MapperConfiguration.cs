using AutoMapper;
using StudyThink.Domain.Entities.Admins;
using StudyThink.Service.DTOs.Admin;

namespace StudyThink.Api.Configurations;

public class MapperConfiguration : Profile
{
    public MapperConfiguration()
    {
        // Admin 
        CreateMap<AdminCreationDto, Admin>().ReverseMap();
        CreateMap<AdminUpdateDto, Admin>().ReverseMap();

        // ...
    }
}
