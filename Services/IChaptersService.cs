using MyFirstBackend.Models.DataModels;

namespace MyFirstBackend.Services
{
    public interface IChaptersService
    {
        Chapter? GetChapterByCourse(int courseId);
    }
}
