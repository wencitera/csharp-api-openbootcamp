using MyFirstBackend.DataAccess;
using MyFirstBackend.Models.DataModels;

namespace MyFirstBackend.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly UniversityDBContext _context;
        public StudentsService(UniversityDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetStudentsWithCourses()
        {
            return _context.Students.Where(student => student.Courses.Any());
        }

        public IEnumerable<Student> GetStudentsWithNoCourses()
        {
            return _context.Students.Where(student => !student.Courses.Any());
        }
    }
}
