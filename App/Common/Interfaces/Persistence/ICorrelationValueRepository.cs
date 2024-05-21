using Domain.Classes.AppDBClasses;

namespace App.Common.Interfaces.Persistence
{
    public interface ICorrelationValueRepository
    {
        void Add(CorrelationValue correlationValue);
        Task<CorrelationValue?> GetLastVersion();
    }
}
