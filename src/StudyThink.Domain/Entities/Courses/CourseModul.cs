namespace StudyThink.Domain.Entities.Courses;

public class CourseModul:Auditable
{
    public string Name { get; set; }
    public int CourseID { get; set; }
    public DateTime CreatedAt { get; set; }= DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; }

}
