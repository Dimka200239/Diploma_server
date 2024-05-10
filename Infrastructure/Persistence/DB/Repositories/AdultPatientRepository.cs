using App.AdultPatients.Query.GetAdultPatientByPassport;
using App.Common.Interfaces.Persistence;
using Azure.Core;
using Domain.Classes;
using Domain.Classes.AppDBClasses;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        public async Task<List<AdultPatient>> FindByName(string[] fullName)
        {
            if (fullName.Length == 1)
            {
                return await _context.AdultPatients
                    .Include(a => a.Addresses)
                    .Where(a => a.Name.Contains(fullName[0]) || a.MiddleName.Contains(fullName[0]) || a.LastName.Contains(fullName[0]))
                    .ToListAsync();
            }
            else if (fullName.Length == 2)
            {
                return await _context.AdultPatients
                    .Include(a => a.Addresses)
                    .Where(a => a.LastName.Contains(fullName[0]) && a.Name.Contains(fullName[1]) || a.Name.Contains(fullName[0]) && a.MiddleName.Contains(fullName[1]))
                    .ToListAsync();
            }
            else if (fullName.Length == 3)
            {
                return await _context.AdultPatients
                    .Include(a => a.Addresses)
                    .Where(a => a.LastName.Contains(fullName[0]) && a.Name.Contains(fullName[1]) && a.MiddleName.Contains(fullName[2]))
                    .ToListAsync();
            }
            else
            {
                return null;
            }
        }

        public async Task<AdultPatient?> FindByPassport(GetAdultPatientByPassportQuery option)
        {
            var timeRegistration = option.DateOfIssue;
            var hashSeries = new HashSecurity(option.Series, timeRegistration);
            var hashNumber = new HashSecurity(option.Number, timeRegistration);

            return await _context.AdultPatients
                .Include(a => a.Addresses)
                .FirstOrDefaultAsync(p => p.Passport.Series.Equals(hashSeries.Text) &&
                                     p.Passport.Number.Equals(hashNumber.Text) &&
                                     p.Passport.DateOfIssue.Equals(timeRegistration));
        }
    }
}
