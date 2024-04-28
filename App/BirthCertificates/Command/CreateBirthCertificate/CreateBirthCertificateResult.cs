using App.Common.Abstractions;
using Domain.Classes.AppDBClasses;

namespace App.BirthCertificates.Command.CreateBirthCertificate
{
    public class CreateBirthCertificateResult : BaseResult
    {
        public BirthCertificate BirthCertificate { get; set; }
    }
}
