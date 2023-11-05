using AutoMapper;
using StudyThink.Domain.Entities.Admins;
using StudyThink.Domain.Entities.Courses;
using StudyThink.Service.DTOs.Admin;
using StudyThink.Service.DTOs.Courses.Course;

namespace StudyThink.Api.Configurations;

public class MapperConfiguration : Profile
{
    public MapperConfiguration()
    {
        // Admin 
        CreateMap<AdminCreationDto, Admin>().ReverseMap();
        CreateMap<AdminUpdateDto, Admin>().ReverseMap();

        // ...

        //Course
        CreateMap<CourseCreationDto,Course>().ReverseMap();
        CreateMap<CourseUpdateDto, Course>().ReverseMap();

        
    }
}
