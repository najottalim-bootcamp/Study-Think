namespace StudyThink.Domain.Entities.Teachers;

public class Teacher : Human
{
    public string Level { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime DateOfBirth { get; set; }

    public string? ImagePath { get; set; }

}