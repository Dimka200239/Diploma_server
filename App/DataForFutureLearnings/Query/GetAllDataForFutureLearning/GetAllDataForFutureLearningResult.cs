using App.Common.Abstractions;
using Domain.Classes.AppDBClasses;

namespace App.DataForFutureLearnings.Query.GetAllDataForFutureLearning
{
    public class GetAllDataForFutureLearningResult : BaseResult
    {
        public List<DataForFutureLearning>? DataForFutureLearnings { get; set; }
    }
}
