using StudyThink.DataAccess.Interfaces.Teachers;
using StudyThink.DataAccess.Repositories.Teachers;

namespace StudyThink.Api.Configurations.Layers;

public static class DataAccessConfiguration
{
    public static void ConfigureDataAccess(this WebApplicationBuilder builder)
    {
        // AutoMapping
        builder.Services.AddAutoMapper(typeof(MapperConfiguration));

        // Database Configurations field

        builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();

    }
}
