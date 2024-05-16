using App.Common.Interfaces.Persistence;
using Domain.Classes.AppDBClasses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.DB.Repositories
{
    public class DataForFutureLearningRepository : IDataForFutureLearningRepository
    {
        private readonly ApplicationContext _context;

        public DataForFutureLearningRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(DataForFutureLearning dataForFutureLearning)
        {
            _context.DataForFutureLearnings.Add(dataForFutureLearning);
        }

        public void AddRange(List<DataForFutureLearning> dataForFutureLearningList)
        {
            _context.DataForFutureLearnings.AddRange(dataForFutureLearningList);
        }

        public void ClearAll()
        {
            _context.DataForFutureLearnings.RemoveRange(_context.DataForFutureLearnings);
        }

        public async Task<List<DataForFutureLearning>?> FindAll()
        {
            return await _context.DataForFutureLearnings
                .ToListAsync();
        }
    }
}
