using App.Common.Interfaces.Persistence;

namespace Infrastructure.Persistence.DB.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        private IEmployeeRepository _employeeRepository;
        private IRefreshTokenRepository _refreshTokenRepository;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        public IEmployeeRepository Employees => _employeeRepository ?? (_employeeRepository = new EmployeeRepository(_context));

        public IRefreshTokenRepository RefreshTokens => _refreshTokenRepository ?? (_refreshTokenRepository = new RefreshTokenRepository(_context));

        public async Task<bool> CompleteAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        private bool _disposed;

        protected virtual async ValueTask DisposeAsync(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    await _context.DisposeAsync();
                }

                _disposed = true;
            }
        }
    }
}
