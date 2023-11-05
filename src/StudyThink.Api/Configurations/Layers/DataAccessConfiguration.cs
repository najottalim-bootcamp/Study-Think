using StudyThink.DataAccess.Interfaces.Categories;
using StudyThink.DataAccess.Interfaces.Teachers;
using StudyThink.DataAccess.Repositories.Categories;
using StudyThink.DataAccess.Repositories.Courses;
using StudyThink.DataAccess.Repositories.Teachers;
using StudyThink.Service.Interfaces.Common;
using StudyThink.Service.Interfaces.Courses;
using StudyThink.Service.Services.Common;

namespace StudyThink.Api.Configurations.Layers;

public static class DataAccessConfiguration
{
    public static void ConfigureDataAccess(this WebApplicationBuilder builder)
    {
        // AutoMapping
        builder.Services.AddAutoMapper(typeof(MapperConfiguration));

        // Database Configurations field
        builder.Services.AddScoped<IFileService, FileService>();
        builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<ICourseRepository, CourseRepository>();

    }
}
