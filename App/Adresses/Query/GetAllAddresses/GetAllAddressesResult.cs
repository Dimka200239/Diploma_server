using App.Common.Abstractions;
using Domain.Classes.AppDBClasses;

namespace App.Adresses.Query.GetAllAddresses
{
    public class GetAllAddressesResult : BaseResult
    {
        public List<Address>? Addresses { get; set; }
    }
}
