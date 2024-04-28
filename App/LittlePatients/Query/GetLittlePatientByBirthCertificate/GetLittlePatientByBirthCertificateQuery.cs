using MediatR;

namespace App.LittlePatients.Query.GetLittlePatientByBirthCertificate
{
    public class GetLittlePatientByBirthCertificateQuery : IRequest<GetLittlePatientByBirthCertificateResult>
    {
        public string Series { get; set; }
        public string Number { get; set; }
        public DateTime DateOfIssue { get; set; }
    }
}
