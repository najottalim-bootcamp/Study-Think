using AutoMapper;
using StudyThink.Domain.Entities.Admins;
using StudyThink.Domain.Entities.Categories;
using StudyThink.Domain.Entities.Courses;
using StudyThink.Service.DTOs.Admin;
using StudyThink.Service.DTOs.Category;
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
        CreateMap<CourseCreationDto, Course>().ReverseMap();
        CreateMap<CourseUpdateDto, Course>().ReverseMap();

        // Categories
        CreateMap<CategoryCreationDto, Category>().ReverseMap();
        CreateMap<CategoryUpdateDto, Category>().ReverseMap();

        // 
    }
}
