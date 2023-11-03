namespace StudyThink.Service.DTOs.Courses.Course;

public class CourseUpdateDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public float Price { get; set; }
    public string ImagePath { get; set; }
    public float TotalPrice { get; set; }
    public int Lessons { get; set; }
    public float Duration { get; set; }
    public string Language { get; set; }
    public float DiscountPrice { get; set; }
    public int CourseReqId { get; set; }

}
