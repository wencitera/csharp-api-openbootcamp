using MyFirstBackend.Models.DataModels;

namespace MyFirstBackend.Services
{
    public interface IStudentsService
    {

        IEnumerable<Student> GetStudentsWithCourses();
        IEnumerable<Student> GetStudentsWithNoCourses();
        IEnumerable<Student> GetStudentsByCourse(int courseId);
    }
}
