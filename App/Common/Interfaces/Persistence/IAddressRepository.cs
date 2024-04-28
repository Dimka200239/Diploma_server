using Domain.Classes.AppDBClasses;

namespace App.Common.Interfaces.Persistence
{
    public interface IAddressRepository
    {
        void Add(Address address);
        Task<List<Address>?> FindAll(int patientId, string role);
    }
}
