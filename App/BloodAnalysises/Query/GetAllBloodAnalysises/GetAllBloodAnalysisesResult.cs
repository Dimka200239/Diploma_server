using App.Common.Abstractions;
using Domain.Classes.AppDBClasses;
namespace App.BloodAnalysises.Query.GetAllBloodAnalysises
{
    public class GetAllBloodAnalysisesResult : BaseResult
    {
        public List<BloodAnalysis>? BloodAnalysises { get; set; }
    }
}
