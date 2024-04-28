using App.Common.Abstractions;
using Domain.Classes.AppDBClasses;

namespace App.AnthropometryOfPatients.Command.CreateAnthropometryOfPatient
{
    public class CreateAnthropometryOfPatientResult : BaseResult
    {
        public AnthropometryOfPatient AnthropometryOfPatient { get; set; }
    }
}
