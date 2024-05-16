using App.Common.Interfaces.Persistence;
using Domain.Classes.AppDBClasses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.DB.Repositories
{
    public class PassportRepository : IPassportRepository
    {
        private readonly ApplicationContext _context;

        public PassportRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Passport?> FindByAdultPatientId(int adultPatientId)
        {
            return await _context.Passports
                .FirstOrDefaultAsync(p => p.AdultPatientId == adultPatientId);
        }

        public void Update(Passport passport)
        {
            _context.Passports.Update(passport);
        }

        public void Add(Passport passport)
        {
            _context.Passports.Add(passport);
        }
    }
}
