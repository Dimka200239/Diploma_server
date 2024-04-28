using MediatR;

namespace App.LittlePatients.Command.CreateLittlePatient
{
    public class CreateLittlePatientCommand : IRequest<CreateLittlePatientResult>
    {
        public string Name { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
    }
}
