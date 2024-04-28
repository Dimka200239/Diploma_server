using MediatR;

namespace App.BirthCertificates.Command.CreateBirthCertificate
{
    public class CreateBirthCertificateCommand : IRequest<CreateBirthCertificateResult>
    {
        public int LittlePatientId { get; set; }
        public string Series { get; set; }
        public string Number { get; set; }
        public DateTime DateOfIssue { get; set; }
    }
}
