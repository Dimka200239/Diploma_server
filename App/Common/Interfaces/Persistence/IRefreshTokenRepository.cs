using Domain.Classes.AppDBClasses;

namespace App.Common.Interfaces.Persistence
{
    public interface IRefreshTokenRepository
    {
        void Remove(RefreshToken refreshToken);
    }
}
