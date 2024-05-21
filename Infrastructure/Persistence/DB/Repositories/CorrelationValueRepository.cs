using App.Common.Interfaces.Persistence;
using Domain.Classes.AppDBClasses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.DB.Repositories
{
    public class CorrelationValueRepository : ICorrelationValueRepository
    {
        private readonly ApplicationContext _context;

        public CorrelationValueRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(CorrelationValue correlationValue)
        {
            _context.CorrelationValues.Add(correlationValue);
        }

        public async Task<CorrelationValue?> GetLastVersion()
        {
            return await _context.CorrelationValues
                .OrderByDescending(m => m.CreatedDate)
                .FirstOrDefaultAsync();
        }
    }
}
