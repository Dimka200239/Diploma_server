using MediatR;

namespace App.AdultPatients.Query.GetAdultPatientByName
{
    public class GetAdultPatientByNameQuery : IRequest<GetAdultPatientByNameResult>
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
    }
}
