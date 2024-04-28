using MediatR;

namespace App.AnthropometryOfPatients.Command.CreateAnthropometryOfPatient
{
    public class CreateAnthropometryOfPatientCommand : IRequest<CreateAnthropometryOfPatientResult>
    {
        public int PatientId { get; set; }
        public string Role { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Age { get; set; }
    }
}
