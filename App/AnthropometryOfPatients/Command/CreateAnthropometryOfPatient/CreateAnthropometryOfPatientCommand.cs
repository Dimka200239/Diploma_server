using MediatR;

namespace App.AnthropometryOfPatients.Command.CreateAnthropometryOfPatient
{
    public class CreateAnthropometryOfPatientCommand : IRequest<CreateAnthropometryOfPatientResult>
    {
        public int PatientId { get; set; }
        public string Role { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public int Age { get; set; }
        public double Waist { get; set; }
        public double Hip { get; set; }
    }
}
