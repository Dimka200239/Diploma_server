using App.AdultPatients.Query.GetAdultPatientByPassport;
using Domain.Classes.AppDBClasses;

namespace App.Common.Interfaces.Persistence
{
    public interface IAdultPatientRepository
    {
        Task<AdultPatient?> FindByPassport(GetAdultPatientByPassportQuery option);
        Task<List<AdultPatient>> FindByName(string fullName, DateTime date, string gender);
        void Add(AdultPatient adultPatient);
        Task<AdultPatient?> FindById(int adultPatientId);
        void Update(AdultPatient adultPatient);
        void Remove(AdultPatient adultPatient);
    }
}
