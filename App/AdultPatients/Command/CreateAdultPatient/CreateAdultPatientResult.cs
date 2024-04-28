using App.Common.Abstractions;
using Domain.Classes.AppDBClasses;

namespace App.AdultPatients.Command.CreateAdultPatient
{
    public class CreateAdultPatientResult : BaseResult
    {
        public int AdultPatientId { get; set; }
    }
}
