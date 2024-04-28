using App.Common.Abstractions;
using Domain.Classes.AppDBClasses;

namespace App.AdultPatients.Query.GetAdultPatientByPassport
{
    public class GetAdultPatientByPassportResult : BaseResult
    {
        public AdultPatient? AdultPatient { get; set; }
    }
}
