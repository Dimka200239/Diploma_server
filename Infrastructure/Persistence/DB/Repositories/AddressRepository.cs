using App.Common.Interfaces.Persistence;
using Domain.Classes.AppDBClasses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.DB.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationContext _context;

        public AddressRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(Address address)
        {
            _context.Add(address);
        }

        public async Task<List<Address>?> FindAll(int patientId, string role)
        {
            return await _context.Addresses
                .Where(a => a.PatientId == patientId && a.Role.Equals(role))
                .OrderBy(a => a.DateOfChange)
                .ToListAsync();
        }
    }
}
