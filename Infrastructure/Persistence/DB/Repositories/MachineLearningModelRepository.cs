using App.Common.Interfaces.Persistence;
using Domain.Classes.AppDBClasses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.DB.Repositories
{
    public class MachineLearningModelRepository : IMachineLearningModelRepository
    {
        private readonly ApplicationContext _context;

        public MachineLearningModelRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(MachineLearningModel machineLearningModel)
        {
            _context.MachineLearningModels.Add(machineLearningModel);
        }

        public async Task<MachineLearningModel?> GetLastVersion()
        {
            return await _context.MachineLearningModels
                .OrderByDescending(m => m.CreatedDate)
                .FirstOrDefaultAsync();
        }
    }
}
