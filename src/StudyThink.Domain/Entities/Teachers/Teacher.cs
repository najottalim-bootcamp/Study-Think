using StudyThink.Domain.Enums;

namespace StudyThink.Domain.Entities.Teachers;

public class Teacher : Human
{
    public TeacherLevel Level { get; set; }

    public string Description { get; set; } = string.Empty;

    public DateTime DateOfBirth { get; set; }

    public string ImagePath { get; set; } = string.Empty;

}