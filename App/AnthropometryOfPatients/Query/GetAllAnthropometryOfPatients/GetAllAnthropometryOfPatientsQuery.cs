using MediatR;

namespace App.AnthropometryOfPatients.Query.GetAllAnthropometryOfPatients
{
    public class GetAllAnthropometryOfPatientsQuery : IRequest<GetAllAnthropometryOfPatientsResult>
    {
        public int ParientId { get; set; }
        public string Role { get; set; }
    }
}
