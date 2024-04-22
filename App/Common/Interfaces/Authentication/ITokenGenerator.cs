using Domain.Classes.AppDBClasses;

namespace App.Common.Interfaces.Authentication
{
    public interface ITokenGenerator
    {
        string GenerateToken(Employee employee);
        RefreshToken GenerateRefreshToken();
    }
}
