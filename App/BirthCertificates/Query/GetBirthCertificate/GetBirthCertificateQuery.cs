using MediatR;

namespace App.BirthCertificates.Query.GetBirthCertificate
{
    public class GetBirthCertificateQuery : IRequest<GetBirthCertificateResult>
    {
        public int LittlePatientId { get; set; }
    }
}
