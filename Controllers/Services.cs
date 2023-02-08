using MyFirstBackend.DataAccess;
using MyFirstBackend.Models.DataModels;

namespace MyFirstBackend.Controllers
{
    public class Services
    {
        private readonly UniversityDBContext _context;

        public Services(UniversityDBContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUserByEmail(string email)
        {
            return _context.Users.Where(user => user.Email == email);
        }
        public IEnumerable<Student> GetUserAgeMoreThan18()
        {
            return _context.Students.Where(student => student.Dob.AddYears(18) < DateTime.Now);
        }
        public IEnumerable<Student> GetUserWithAnyCourses()
        {
            return _context.Students.Where(student => student.Courses.Any());
        }
        public IEnumerable<Course> GetCoursesByLevelAndStudentMoreThanZero(Level level)
        {
            return _context.Courses.Where(course => course.Students.Any() && course.Level == level);
        }
        public IEnumerable<Course> GetCoursesByLevelAndStudentMoreThanZero(Level level, Category category)
        {
            return _context.Courses.Where(course => course.Level == level && course.Categories.Contains(category));
        }
        public IEnumerable<Course> GetCoursesWithoutStudents()
        { 
            return _context.Courses.Where(course => !course.Students.Any()); 
        }


    }
}
