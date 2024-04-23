namespace App.Common.Interfaces.Persistence
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employees { get; }
        IRefreshTokenRepository RefreshTokens { get; }
        Task<bool> CompleteAsync();
    }
}
