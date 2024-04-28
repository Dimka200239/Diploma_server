using App.Common.Abstractions;
using Domain.Classes.AppDBClasses;

namespace App.LittlePatients.Command.UpdateLittlePatient
{
    public class UpdateLittlePatientResult : BaseResult
    {
        public LittlePatient LittlePatient { get; set; }
    }
}
