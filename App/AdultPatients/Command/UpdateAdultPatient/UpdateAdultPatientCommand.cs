using MediatR;

namespace App.AdultPatients.Command.UpdateAdultPatient
{
    public class UpdateAdultPatientCommand : IRequest<UpdateAdultPatientResult>
    {
        public int AdultPatientId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
