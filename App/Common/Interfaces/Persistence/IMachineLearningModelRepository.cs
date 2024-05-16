using Domain.Classes.AppDBClasses;

namespace App.Common.Interfaces.Persistence
{
    public interface IMachineLearningModelRepository
    {
        void Add(MachineLearningModel machineLearningModel);
        Task<MachineLearningModel?> GetLastVersion();
    }
}
