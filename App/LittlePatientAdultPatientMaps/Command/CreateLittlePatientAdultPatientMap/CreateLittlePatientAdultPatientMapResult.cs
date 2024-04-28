using App.Common.Abstractions;
using Domain.Classes.AppDBClasses;

namespace App.LittlePatientAdultPatientMaps.Command.CreateLittlePatientAdultPatientMap
{
    public class CreateLittlePatientAdultPatientMapResult : BaseResult
    {
        public LittlePatientAdultPatientMap LittlePatientAdultPatientMap { get; set; }
    }
}
