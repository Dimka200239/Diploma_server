using Domain.Classes.AppDBClasses;

namespace App.Common.Interfaces.Persistence
{
    public interface IPassportRepository
    {
        Task<Passport?> FindByAdultPatientId(int adultPatientId);
        void Update(Passport passport);
        void Add(Passport passport);
    }
}
