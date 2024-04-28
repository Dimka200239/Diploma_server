using App.Common.Abstractions;
using Domain.Classes.AppDBClasses;

namespace App.LittlePatients.Query.GetLittlePatientByBirthCertificate
{
    public class GetLittlePatientByBirthCertificateResult : BaseResult
    {
        public LittlePatient? LittlePatient { get; set; }
    }
}
