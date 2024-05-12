using MediatR;

namespace App.AdultPatients.Query.GetAdultPatientByIdWithAnthropometryAndLifestyle
{
    public class GetAdultPatientByIdWithAnthropometryAndLifestyleQuery : IRequest<GetAdultPatientByIdWithAnthropometryAndLifestyleResult>
    {
        public int AdultPatientId { get; set; }
    }
}
