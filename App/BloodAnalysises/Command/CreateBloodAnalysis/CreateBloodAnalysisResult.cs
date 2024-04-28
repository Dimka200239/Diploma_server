using App.Common.Abstractions;
using Domain.Classes.AppDBClasses;

namespace App.BloodAnalysises.Command.CreateBloodAnalysis
{
    public class CreateBloodAnalysisResult : BaseResult
    {
        public BloodAnalysis BloodAnalysis { get; set; }
    }
}
