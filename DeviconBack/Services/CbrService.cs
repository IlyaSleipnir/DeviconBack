using DeviconBack.Data;
using DeviconBack.Data.Entities;
using DeviconBack.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DeviconBack.Services
{
    public class CbrService : ICbrService
    {
        private readonly ICbrClient _client;
        private readonly AppDbContext _dbContext;

        public CbrService(ICbrClient client, AppDbContext dbContext)
        {
            _client = client;
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ValuteCourse>> GetLatestCourses()
        {
            return (await GetCoursesInLastMonth()).Take(10);
        }

        public Task<IEnumerable<ValuteCourse>> GetCoursesInLastMonth()
        {
            var toDate = DateTime.Now.Date;
            var fromDate = toDate.AddMonths(-1);

            return GetCoursesInInterval(fromDate, toDate);
        }

        public async Task<IEnumerable<ValuteCourse>> GetCoursesInInterval(DateTime fromDate, DateTime toDate)
        {
            //await using var dbContext = new AppDbContext();
            var courses = await _dbContext.ValuteCourses
                .Include(x => x.Valutes)
                .Where(x => x.Date <= toDate && x.Date >= fromDate)
                .ToListAsync();

            // Если не хватает записей
            if (courses.Count != (toDate - fromDate).Days)
            {
                var currentDate = toDate;

                while (currentDate >= fromDate)
                {
                    await LoadDataToCourses(courses, currentDate);
                    currentDate = currentDate.AddDays(-1);
                }

                await _dbContext.SaveChangesAsync();
            }

            return courses.OrderByDescending(x => x.Date);
        }

        private async Task LoadDataToCourses(List<ValuteCourse> courses, DateTime currentDate)
        {
            if (courses.FirstOrDefault(x => x.Date.Date == currentDate.Date) == null)
            {
                try
                {
                    var loadedCourse = await _client.LoadData(currentDate);

                    if (loadedCourse != null && loadedCourse.Date == currentDate)
                    {
                        courses.Add(loadedCourse);
                        if (_dbContext.ValuteCourses.FirstOrDefault(x => x.Date == loadedCourse.Date) == null)
                        {
                            await _dbContext.AddAsync(loadedCourse);
                        }
                    }
                }
                catch (Exception ex)
                {
                    var a = ex.Message;
                }
            }
        }
    }
}
