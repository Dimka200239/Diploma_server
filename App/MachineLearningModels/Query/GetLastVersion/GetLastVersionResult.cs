using App.Common.Abstractions;
using Domain.Classes.AppDBClasses;

namespace App.MachineLearningModels.Query.GetLastVersion
{
    public class GetLastVersionResult : BaseResult
    {
        public MachineLearningModel? MachineLearningModel { get; set; }
    }
}
