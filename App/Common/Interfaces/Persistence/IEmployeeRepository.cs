using Domain.Classes.AppDBClasses;

namespace App.Common.Interfaces.Persistence
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        void Update(Employee employee);
        Task<Employee> FindByLogin(string login);
        Task<Employee> GetUserCheckToken(string token);
        Task<bool> ContainsLogin(string login);
    }
}
