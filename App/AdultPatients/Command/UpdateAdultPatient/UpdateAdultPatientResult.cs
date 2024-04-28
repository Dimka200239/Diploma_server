using App.Common.Abstractions;
using Domain.Classes.AppDBClasses;

namespace App.AdultPatients.Command.UpdateAdultPatient
{
    public class UpdateAdultPatientResult : BaseResult
    {
        public AdultPatient AdultPatient { get; set; }
    }
}
