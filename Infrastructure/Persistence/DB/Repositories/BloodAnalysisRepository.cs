using App.Common.Interfaces.Persistence;
using Domain.Classes.AppDBClasses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.DB.Repositories
{
    public class BloodAnalysisRepository : IBloodAnalysisRepository
    {
        private readonly ApplicationContext _context;

        public BloodAnalysisRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(BloodAnalysis address)
        {
            _context.Add(address);
        }

        public async Task<List<BloodAnalysis>?> FindAll(int patientId, string role)
        {
            return await _context.BloodAnalysises
                .Where(a => a.PatientId == patientId && a.Role.Equals(role))
                .OrderBy(a => a.DateOfChange)
                .ToListAsync();
        }
    }
}
