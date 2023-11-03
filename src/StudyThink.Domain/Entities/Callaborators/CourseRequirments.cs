namespace StudyThink.Domain.Entities.Callaborators;

public class CourseRequirments : Auditable
{
    public long CourseId { get; set; }
    public string Requirments { get; set; }
}
