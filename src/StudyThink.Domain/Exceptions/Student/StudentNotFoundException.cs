namespace StudyThink.Domain.Exceptions.Student
{
    public class StudentNotFoundException : NotFoundException
    {
        public StudentNotFoundException()
        {
            TitleMessage = "Student Not Found!";
        }
    }
}
