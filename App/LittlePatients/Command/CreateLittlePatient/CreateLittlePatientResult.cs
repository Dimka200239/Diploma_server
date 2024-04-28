using App.Common.Abstractions;

namespace App.LittlePatients.Command.CreateLittlePatient
{
    public class CreateLittlePatientResult : BaseResult
    {
        public int LittlePatientId { get; set; }
    }
}
