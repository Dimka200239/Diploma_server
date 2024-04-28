using MediatR;

namespace App.Adresses.Command.CreateAddress
{
    public class CreateAddressCommand : IRequest<CreateAddressResult>
    {
        public int PatientId { get; set; }
        public string Role { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int House { get; set; }
        public int? Apartment { get; set; }
    }
}
