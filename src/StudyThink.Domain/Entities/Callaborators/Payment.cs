namespace StudyThink.Domain.Entities.Callaborators;

public class Payment : BaseEntity
{

    public string Type { get; set; }
    public string Status { get; set; }
    public string Description { get; set; }
    public int CourseId { get; set; }
}
