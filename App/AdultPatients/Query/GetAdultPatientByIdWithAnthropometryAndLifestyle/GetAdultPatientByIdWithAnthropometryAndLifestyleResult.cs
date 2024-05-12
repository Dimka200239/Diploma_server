using App.Common.Abstractions;
using Domain.Classes.AppDBClasses;

namespace App.AdultPatients.Query.GetAdultPatientByIdWithAnthropometryAndLifestyle
{
    public class GetAdultPatientByIdWithAnthropometryAndLifestyleResult : BaseResult
    {
        public AnthropometryOfPatient? AnthropometryOfPatient { get; set; }
        public Lifestyle? Lifestyle { get; set; }
    }
}
