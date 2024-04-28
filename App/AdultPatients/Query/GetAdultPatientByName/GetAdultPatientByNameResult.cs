using App.Common.Abstractions;
using Domain.Classes.AppDBClasses;

namespace App.AdultPatients.Query.GetAdultPatientByName
{
    public class GetAdultPatientByNameResult : BaseResult
    {
        public List<AdultPatient>? AdultPatients { get; set; }
    }
}
