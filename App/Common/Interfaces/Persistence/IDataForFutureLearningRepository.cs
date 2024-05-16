using Domain.Classes.AppDBClasses;

namespace App.Common.Interfaces.Persistence
{
    public interface IDataForFutureLearningRepository
    {
        void Add(DataForFutureLearning dataForFutureLearning);
        void AddRange(List<DataForFutureLearning> dataForFutureLearningList);
        void ClearAll();
        Task<List<DataForFutureLearning>?> FindAll();
    }
}
