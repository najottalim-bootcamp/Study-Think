namespace StudyThink.Domain.Entities.Courses;

public class CourseRequirments : Auditable
{
    public long CourseId { get; set; }
    public string Requirments { get; set; }
}
