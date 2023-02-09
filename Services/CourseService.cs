using MyFirstBackend.DataAccess;
using MyFirstBackend.Models.DataModels;

namespace MyFirstBackend.Services
{
    public class CourseService : ICoursesService
    {
        private readonly UniversityDBContext _context;
        public CourseService(UniversityDBContext context)
        {
            _context = context;
        }
        public IEnumerable<Course> GetCoursesByCategory(int categoryId)
        {
            return _context.Courses.Where(course => course.Categories.Any(cat => cat.Id == categoryId));
        }

        public IEnumerable<Course> GetCoursesWithNoChapters()
        {
            return _context.Courses.Where(course => course.Chapter.List != "");
        }
    }
}
