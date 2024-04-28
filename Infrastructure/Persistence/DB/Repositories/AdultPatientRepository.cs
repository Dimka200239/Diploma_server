using App.AdultPatients.Query.GetAdultPatientByPassport;
using App.Common.Interfaces.Persistence;
using Domain.Classes.AppDBClasses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.DB.Repositories
{
    public class AdultPatientRepository : IAdultPatientRepository
    {
        private readonly ApplicationContext _context;

        public AdultPatientRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(AdultPatient adultPatient)
        {
            _context.Add(adultPatient);
        }

        public void Update(AdultPatient adultPatient)
        {
            _context.Update(adultPatient);
        }

        public void Remove(AdultPatient adultPatient)
        {
            _context.Remove(adultPatient);
        }

        public async Task<AdultPatient?> FindById(int adultPatientId)
        {
            return await _context.AdultPatients
                .Include(a => a.Passport)
                .Include(a => a.Addresses)
                .Include(a => a.AnthropometryOfPatients)
                .Include(a => a.Lifestyles)
                .Include(a => a.BloodAnalysises)
                .FirstOrDefaultAsync(a => a.Id == adultPatientId);
        }

        public async Task<List<AdultPatient>> FindByName(string fullName, DateTime date, string gender)
        {
            return await _context.AdultPatients
                .Include(a => a.Passport)
                .Include(a => a.Addresses)
                .Include(a => a.AnthropometryOfPatients)
                .Include(a => a.Lifestyles)
                .Include(a => a.BloodAnalysises)
                .Where(a => a.GetFullName.Contains(fullName) && a.DateOfBirth == date && a.Gender.Equals(gender))
                .ToListAsync();
        }

        public async Task<AdultPatient?> FindByPassport(GetAdultPatientByPassportQuery option)
        {
            return await _context.AdultPatients
                .Include(a => a.Passport)
                .Include(a => a.Addresses)
                .Include(a => a.AnthropometryOfPatients)
                .Include(a => a.Lifestyles)
                .Include(a => a.BloodAnalysises)
                .FirstOrDefaultAsync(p => p.Passport.Series.Equals(option.Series) &&
                                     p.Passport.Number.Equals(option.Number) &&
                                     p.Passport.Code.Equals(option.Code) &&
                                     p.Passport.DateOfIssue.Equals(option.DateOfIssue));
        }
    }
}
