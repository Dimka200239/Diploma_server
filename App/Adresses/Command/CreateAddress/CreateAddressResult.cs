using App.Common.Abstractions;
using Domain.Classes.AppDBClasses;

namespace App.Adresses.Command.CreateAddress
{
    public class CreateAddressResult : BaseResult
    {
        public Address? Address { get; set; }
    }
}
