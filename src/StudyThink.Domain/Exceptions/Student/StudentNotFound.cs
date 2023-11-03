namespace StudyThink.Domain.Exceptions.Student;

public class StudentNotFound:NotFoundException
{
    public StudentNotFound()
    {
        TitleMessage = "Student not found";
    }
}
