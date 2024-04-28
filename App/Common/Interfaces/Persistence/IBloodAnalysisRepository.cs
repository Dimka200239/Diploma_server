using Domain.Classes.AppDBClasses;

namespace App.Common.Interfaces.Persistence
{
    public interface IBloodAnalysisRepository
    {
        void Add(BloodAnalysis address);
        Task<List<BloodAnalysis>?> FindAll(int patientId, string role);
    }
}
