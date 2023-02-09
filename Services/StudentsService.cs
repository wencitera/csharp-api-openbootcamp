using MyFirstBackend.Models.DataModels;

namespace MyFirstBackend.Services
{
    public class StudentsService : IStudentsService
    {
        public IEnumerable<Student> GetStudentsWithCourses()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetStudentsWithNoCourses()
        {
            throw new NotImplementedException();
        }
    }
}
