using DeviconBack.Data.Entities;

namespace DeviconBack.Services.Interfaces
{
    public interface ICbrService
    {
        public Task<IEnumerable<ValuteCourse>> GetLatestCourses();
        public Task<IEnumerable<ValuteCourse>> GetCoursesInLastMonth();
        public Task<IEnumerable<ValuteCourse>> GetCoursesInInterval(DateTime fromDate, DateTime toDate);
    }
}
