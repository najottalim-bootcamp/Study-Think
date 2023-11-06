using StudyThink.Service.Interfaces.Categories;
using StudyThink.Service.Interfaces.Collobarators;
using StudyThink.Service.Interfaces.Courses;
using StudyThink.Service.Interfaces.Payments;
using StudyThink.Service.Interfaces.Studentsk;
using StudyThink.Service.Interfaces.Teachers;
using StudyThink.Service.Services.Callaborators;
using StudyThink.Service.Services.Categories;
using StudyThink.Service.Services.Courses;
using StudyThink.Service.Services.Payments;
using StudyThink.Service.Services.Students;
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
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<ICallaboratorsService, CallaboratorService>();
        builder.Services.AddScoped<IPaymentService, PaymentService>();
        builder.Services.AddScoped<IStudentService, StudentService>();


    }
}
