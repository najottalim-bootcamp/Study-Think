namespace StudyThink.Domain.Entities.Courses;

public class CourseRequirment : Auditable
{
    public long CourseId { get; set; }

    public string Requirments { get; set; }
}
