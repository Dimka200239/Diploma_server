using App.LittlePatients.Query.GetLittlePatientByBirthCertificate;
using Domain.Classes.AppDBClasses;

namespace App.Common.Interfaces.Persistence
{
    public interface ILittlePatientRepository
    {
        Task<LittlePatient?> FindByBirthCertificate(GetLittlePatientByBirthCertificateQuery option);
        Task<List<LittlePatient>> FindByName(string fullName, DateTime date, string gender);
        void Add(LittlePatient littlePatient);
        Task<LittlePatient?> FindById(int littlePatientId);
        void Update(LittlePatient littlePatient);
        void Remove(LittlePatient littlePatient);
    }
}
