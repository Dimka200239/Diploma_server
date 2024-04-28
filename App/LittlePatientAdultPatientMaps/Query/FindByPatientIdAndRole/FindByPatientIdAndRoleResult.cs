using App.Common.Abstractions;
using Domain.Classes.AppDBClasses;

namespace App.LittlePatientAdultPatientMaps.Query.FindByPatientIdAndRole
{
    public class FindByPatientIdAndRoleResult : BaseResult
    {
        public LittlePatientAdultPatientMap LittlePatientAdultPatientMap { get; set; }
    }
}
