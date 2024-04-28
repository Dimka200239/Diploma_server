using Domain.Classes.AppDBClasses;

namespace App.Common.Interfaces.Persistence
{
    public interface ILifestyleRepository
    {
        void Add(Lifestyle address);
        Task<List<Lifestyle>?> FindAll(int patientId, string role);
    }
}
