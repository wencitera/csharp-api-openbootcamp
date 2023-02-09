using MyFirstBackend.DataAccess;
using MyFirstBackend.Models.DataModels;

namespace MyFirstBackend.Services
{
    public class ChaptersService : IChaptersService
    {
        private readonly UniversityDBContext _context;

        public ChaptersService(UniversityDBContext context)
        {
            _context = context;
        }

        public Chapter? GetChapterByCourse(int courseId)
        {
            return _context.Chapters.FirstOrDefault(c => c.CourseId == courseId);
        }
    }
}
