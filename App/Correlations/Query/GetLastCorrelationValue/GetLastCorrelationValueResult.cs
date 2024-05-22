using App.Common.Abstractions;
using Domain.Classes.AppDBClasses;

namespace App.Correlations.Query.GetLastCorrelationValue
{
    public class GetLastCorrelationValueResult : BaseResult
    {
        public CorrelationValue? CorrelationValue { get; set; }
    }
}
