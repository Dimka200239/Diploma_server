using App.Common.Interfaces.Persistence;
using Domain.Classes.AppDBClasses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.DB.Repositories
{
    public class BirthCertificateRepository : IBirthCertificateRepository
    {
        private readonly ApplicationContext _context;

        public BirthCertificateRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(BirthCertificate birthCertificate)
        {
            _context.Add(birthCertificate);
        }

        public async Task<BirthCertificate?> FindByLittlePatientId(int littlePatientId)
        {
            return await _context.BirthCertificates
                .FirstOrDefaultAsync(p => p.LittlePatientId == littlePatientId);
        }

        public void Update(BirthCertificate birthCertificate)
        {
            _context.Update(birthCertificate);
        }
    }
}
