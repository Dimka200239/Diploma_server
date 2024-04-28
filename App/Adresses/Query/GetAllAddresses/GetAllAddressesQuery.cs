using MediatR;

namespace App.Adresses.Query.GetAllAddresses
{
    public class GetAllAddressesQuery : IRequest<GetAllAddressesResult>
    {
        public int ParientId { get; set; }
        public string Role {  get; set; }
    }
}
