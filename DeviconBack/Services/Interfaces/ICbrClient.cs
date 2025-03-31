using DeviconBack.Data.Entities;

namespace DeviconBack.Services.Interfaces
{
    public interface ICbrClient
    {
        public Task<ValuteCourse?> LoadData(DateTime date);
    }
}
