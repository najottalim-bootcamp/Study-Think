namespace StudyThink.Service.DTOs.Courses.CourseComment;

public class CourseCommentResultDto
{
    public string Comment { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public int AdminId { get; set; }
}
