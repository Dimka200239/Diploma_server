using App.Common.Abstractions;
using Domain.Classes.AppDBClasses;

namespace App.BirthCertificates.Query.GetBirthCertificate
{
    public class GetBirthCertificateResult : BaseResult
    {
        public BirthCertificate BirthCertificates { get; set; }
    }
}
