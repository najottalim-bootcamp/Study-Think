namespace StudyThink.Domain.Entities.Payments;

public class Payment : BaseEntity
{

    public string Type { get; set; }
    public string Status { get; set; }
    public string Description { get; set; }
    public long CourseId { get; set; }
}
