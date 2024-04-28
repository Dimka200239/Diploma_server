using App.Common.Abstractions;
using Domain.Classes.AppDBClasses;

namespace App.LittlePatients.Query.GetLittlePatientByName
{
    public class GetLittlePatientByNameResult : BaseResult
    {
        public List<LittlePatient>? LittlePatients { get; set; }
    }
}
