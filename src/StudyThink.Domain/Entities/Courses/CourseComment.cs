﻿namespace StudyThink.Domain.Entities.Course;

public class CourseComment:Auditable
{
    public string Comment { get; set; }
    public long StudentId { get; set; }
    public long CourseId { get;set; }
    public long AdminId { get; set;}

}
