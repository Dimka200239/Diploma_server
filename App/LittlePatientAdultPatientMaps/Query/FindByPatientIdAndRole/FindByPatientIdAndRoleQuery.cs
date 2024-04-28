using MediatR;

namespace App.LittlePatientAdultPatientMaps.Query.FindByPatientIdAndRole
{
    public class FindByPatientIdAndRoleQuery : IRequest<FindByPatientIdAndRoleResult>
    {
        public int PatientId { get; set; }
        public string Role {  get; set; }
    }
}
