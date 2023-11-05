using StudyThink.Service.Interfaces.Courses;
using StudyThink.Service.Interfaces.Teachers;
using StudyThink.Service.Services.Courses;
using StudyThink.Service.Services.Teachers;

namespace StudyThink.Api.Configurations.Layers;

public static class ServiceLayerConfiguration
{
    public static void ConfigureServiceLayer(this WebApplicationBuilder builder)
    {
        // Services Configurations field

        // builder.Services.AddScoped<>();
        builder.Services.AddScoped<ICourseService, CourseService>();
        builder.Services.AddScoped<ITeacherService, TeacherService>();



    }
}
