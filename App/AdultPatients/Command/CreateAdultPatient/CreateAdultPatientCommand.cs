using MediatR;

namespace App.AdultPatients.Command.CreateAdultPatient
{
    public class CreateAdultPatientCommand : IRequest<CreateAdultPatientResult>
    {
        public string Name { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
    }
}
