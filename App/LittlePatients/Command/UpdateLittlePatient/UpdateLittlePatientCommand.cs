using MediatR;

namespace App.LittlePatients.Command.UpdateLittlePatient
{
    public class UpdateLittlePatientCommand : IRequest<UpdateLittlePatientResult>
    {
        public int LittlePatientId { get; set; }
        public string Name { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
    }
}
