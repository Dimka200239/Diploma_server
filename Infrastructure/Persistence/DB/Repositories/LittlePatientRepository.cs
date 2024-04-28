using App.AdultPatients.Query.GetAdultPatientByPassport;
using App.Common.Interfaces.Persistence;
using App.LittlePatients.Query.GetLittlePatientByBirthCertificate;
using Domain.Classes.AppDBClasses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.DB.Repositories
{
    public class LittlePatientRepository : ILittlePatientRepository
    {
        private readonly ApplicationContext _context;

        public LittlePatientRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(LittlePatient littlePatient)
        {
            _context.Add(littlePatient);
        }

        public void Update(LittlePatient littlePatient)
        {
            _context.Update(littlePatient);
        }

        public void Remove(LittlePatient littlePatient)
        {
            _context.Remove(littlePatient);
        }

        public async Task<LittlePatient?> FindById(int littlePatientId)
        {
            return await _context.LittlePatients
                .Include(a => a.BirthCertificate)
                .Include(a => a.Addresses)
                .Include(a => a.AnthropometryOfPatients)
                .Include(a => a.Lifestyles)
                .Include(a => a.BloodAnalysises)
                .FirstOrDefaultAsync(a => a.Id == littlePatientId);
        }

        public async Task<List<LittlePatient>> FindByName(string fullName, DateTime date, string gender)
        {
            return await _context.LittlePatients
                .Include(a => a.BirthCertificate)
                .Include(a => a.Addresses)
                .Include(a => a.AnthropometryOfPatients)
                .Include(a => a.Lifestyles)
                .Include(a => a.BloodAnalysises)
                .Where(a => a.GetFullName.Contains(fullName) && a.DateOfBirth == date && a.Gender.Equals(gender))
                .ToListAsync();
        }

        public async Task<LittlePatient?> FindByBirthCertificate(GetLittlePatientByBirthCertificateQuery option)
        {
            return await _context.LittlePatients
                .Include(a => a.BirthCertificate)
                .Include(a => a.Addresses)
                .Include(a => a.AnthropometryOfPatients)
                .Include(a => a.Lifestyles)
                .Include(a => a.BloodAnalysises)
                .FirstOrDefaultAsync(p => p.BirthCertificate.Series.Equals(option.Series) &&
                                     p.BirthCertificate.Number.Equals(option.Number) &&
                                     p.BirthCertificate.DateOfIssue.Equals(option.DateOfIssue));
        }
    }
}
