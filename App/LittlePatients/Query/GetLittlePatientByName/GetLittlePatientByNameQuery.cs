using MediatR;

namespace App.LittlePatients.Query.GetLittlePatientByName
{
    public class GetLittlePatientByNameQuery : IRequest<GetLittlePatientByNameResult>
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
    }
}
