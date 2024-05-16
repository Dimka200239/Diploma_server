using App.Common.Interfaces.Persistence;
using Domain.Classes.AppDBClasses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.DB.Repositories
{
    public class DateForForecastingRepository : IDateForForecastingRepository
    {
        private readonly ApplicationContext _context;

        public DateForForecastingRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void AddRange(List<DateForForecasting> dateForForecastingList)
        {
            _context.DateForForecastings.AddRange(dateForForecastingList);
        }

        public async Task<List<DateForForecasting>?> FindAll()
        {
            return await _context.DateForForecastings
                .ToListAsync();
        }
    }
}
