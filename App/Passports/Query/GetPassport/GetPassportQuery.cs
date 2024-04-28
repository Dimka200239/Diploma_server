using MediatR;

namespace App.Passports.Query.GetPassport
{
    public class GetPassportQuery : IRequest<GetPassportResult>
    {
        public int AdultPatientId { get; set; }
    }
}
