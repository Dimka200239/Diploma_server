using App.Common.Interfaces.Persistence;
using Domain.Classes.AppDBClasses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.DB.Repositories
{
    public class LifestyleRepository : ILifestyleRepository
    {
        private readonly ApplicationContext _context;

        public LifestyleRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(Lifestyle address)
        {
            _context.Add(address);
        }

        public async Task<List<Lifestyle>?> FindAll(int patientId, string role)
        {
            return await _context.Lifestyles
                .Where(a => a.PatientId == patientId && a.Role.Equals(role))
                .OrderBy(a => a.DateOfChange)
                .ToListAsync();
        }
    }
}
