namespace StudyThink.Domain.Entities.Courses;

public class CourseRequirment:Auditable
{
    public  string Requirments { get; set; }
    public int CourceId { get; set; }
    public DateTime CretedAt { get; set; }=DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; }

}
