using App.Common.Interfaces.Persistence;
using AutoMapper;
using Domain.Classes.AppDBClasses;

namespace Infrastructure.Persistence.DB.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationContext _context;

        public EmployeeRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
        }

        public async Task<bool> ContainsLogin(string login)
        {
            return _context.Employees.Any(u => u.Login == login);
        }

        public void Update(Employee employee)
        {
            _context.Employees.Update(employee);
        }
    }
}
