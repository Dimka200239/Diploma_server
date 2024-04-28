using MediatR;

namespace App.AdultPatients.Command.UpdatePassport
{
    public class UpdatePassportCommand : IRequest<UpdatePassportResult>
    {
        public int AdultPatientId { get; set; }
        public string NewSeries { get; set; }
        public string NewNumber { get; set; }
        public string NewCode { get; set; }
        public DateTime NewDateOfIssue { get; set; }
    }
}
