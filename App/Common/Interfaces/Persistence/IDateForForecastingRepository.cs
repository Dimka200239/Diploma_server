using Domain.Classes.AppDBClasses;

namespace App.Common.Interfaces.Persistence
{
    public interface IDateForForecastingRepository
    {
        void AddRange(List<DateForForecasting> dateForForecastingList);
        Task<List<DateForForecasting>?> FindAll();
    }
}
