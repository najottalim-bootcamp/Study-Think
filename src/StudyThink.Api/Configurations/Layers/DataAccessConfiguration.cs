using StudyThink.DataAccess.Interfaces.Categories;
using StudyThink.DataAccess.Interfaces.Payments;
using StudyThink.DataAccess.Interfaces.Teachers;
using StudyThink.DataAccess.Repositories.Categories;
using StudyThink.DataAccess.Repositories.Courses;
using StudyThink.DataAccess.Repositories.Payments;
using StudyThink.DataAccess.Repositories.Teachers;
using StudyThink.Service.Interfaces.Common;
using StudyThink.Service.Interfaces.Courses;
using StudyThink.Service.Services.Common;

namespace StudyThink.Api.Configurations.Layers;

public static class DataAccessConfiguration
{
    public static void ConfigureDataAccess(this WebApplicationBuilder builder)
    {
        string ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        // AutoMapping
        builder.Services.AddAutoMapper(typeof(MapperConfiguration));

        // Database Configurations field
        builder.Services.AddScoped<IFileService, FileService>();
        builder.Services.AddScoped<ITeacherRepository>(x => new TeacherRepository(ConnectionString));
        builder.Services.AddScoped<ICategoryRepository>(x => new CategoryRepository(ConnectionString));
        builder.Services.AddScoped<ICourseRepository>(x => new CourseRepository(ConnectionString));
        builder.Services.AddScoped<IPaymentRepository>(x => new PaymentRepository(ConnectionString));
        builder.Services.AddScoped<IPaymentDetailsRepository>(x => new PaymentDetailsRepository(ConnectionString));


    }
}
