using MyFirstBackend.Models.DataModels;

namespace MyFirstBackend.Services
{
    public interface ICoursesService
    {
        IEnumerable<Course> GetCoursesByCategory(int categoryId);

        IEnumerable<Course> GetCoursesWithNoChapters();
    }
}
