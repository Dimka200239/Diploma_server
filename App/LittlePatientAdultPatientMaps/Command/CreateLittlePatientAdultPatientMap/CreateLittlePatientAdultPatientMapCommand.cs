using MediatR;

namespace App.LittlePatientAdultPatientMaps.Command.CreateLittlePatientAdultPatientMap
{
    public class CreateLittlePatientAdultPatientMapCommand : IRequest<CreateLittlePatientAdultPatientMapResult>
    {
        public int AdultPatientId { get; set; }
        public int LittlePatientId { get; set; }
    }
}
