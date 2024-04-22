using AutoMapper;
using Domain.Classes.AppDBClasses;

namespace App.Common.Interfaces.Persistence
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        void Update(Employee employee);
        Task<bool> ContainsLogin(string login);
    }
}
