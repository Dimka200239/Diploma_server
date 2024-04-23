using App.Common.Interfaces.Persistence;
using Domain.Classes.AppDBClasses;

namespace Infrastructure.Persistence.DB.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly ApplicationContext _context;

        public RefreshTokenRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Remove(RefreshToken refreshToken)
        {
            _context.Remove(refreshToken);
        }
    }
}
