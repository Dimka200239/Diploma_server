using App.Common.Interfaces.Persistence;
using Domain.Classes.AppDBClasses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.DB.Repositories
{
    public class AnthropometryOfPatientRepository : IAnthropometryOfPatientRepository
    {
        private readonly ApplicationContext _context;

        public AnthropometryOfPatientRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(AnthropometryOfPatient anthropometryOfPatient)
        {
            _context.Add(anthropometryOfPatient);
        }

        public async Task<List<AnthropometryOfPatient>?> FindAll(int patientId, string role)
        {
            return await _context.AnthropometryOfPatients
                .Where(a => a.PatientId == patientId && a.Role.Equals(role))
                .OrderBy(a => a.DateOfChange)
                .ToListAsync();
        }
    }
}
