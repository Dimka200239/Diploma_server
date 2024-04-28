using App.Common.Abstractions;
using Domain.Classes.AppDBClasses;

namespace App.AnthropometryOfPatients.Query.GetAllAnthropometryOfPatients
{
    public class GetAllAnthropometryOfPatientsResult : BaseResult
    {
        public List<AnthropometryOfPatient>? AnthropometryOfPatients { get; set; }
    }
}
