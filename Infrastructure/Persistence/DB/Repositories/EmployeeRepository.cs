using App.Common.Interfaces.Persistence;
using Domain.Classes.AppDBClasses;
using Microsoft.EntityFrameworkCore;

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

        public Task<Employee> FindByLogin(string login)
        {
            return _context.Employees.FirstOrDefaultAsync(u => u.Login == login);
        }

        public async Task<Employee> GetUserCheckToken(string token)
        {
            return await _context.Employees
                .Include(m => m.RefreshTokens)
                .FirstOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token));
        }

        public void Update(Employee employee)
        {
            _context.Employees.Update(employee);
        }
    }
}
