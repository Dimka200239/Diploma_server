namespace App.Common.Interfaces.Persistence
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employees { get; }
        Task<bool> CompleteAsync();
    }
}
