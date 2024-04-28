using Domain.Classes.AppDBClasses;

namespace App.Common.Interfaces.Persistence
{
    public interface IBirthCertificateRepository
    {
        Task<BirthCertificate?> FindByLittlePatientId(int littlePatientId);
        void Update(BirthCertificate birthCertificate);
        void Add(BirthCertificate birthCertificate);
    }
}
