using Domain.Classes.AppDBClasses;

namespace App.Common.Interfaces.Persistence
{
    public interface IAnthropometryOfPatientRepository
    {
        void Add(AnthropometryOfPatient anthropometryOfPatient);
        Task<List<AnthropometryOfPatient>?> FindAll(int patientId, string role);
    }
}
