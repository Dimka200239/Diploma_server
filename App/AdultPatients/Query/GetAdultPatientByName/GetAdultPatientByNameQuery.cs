using MediatR;

namespace App.AdultPatients.Query.GetAdultPatientByName
{
    public class GetAdultPatientByNameQuery : IRequest<GetAdultPatientByNameResult>
    {
        public string Name { get; set; }
    }
}
