using App.Common.Interfaces.Persistence;
using Domain.Classes.AppDBClasses;
using Domain.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.DB.Repositories
{
    public class LittlePatientAdultPatientMapReposirory : ILittlePatientAdultPatientMapReposirory
    {
        private readonly ApplicationContext _context;

        public LittlePatientAdultPatientMapReposirory(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(LittlePatientAdultPatientMap littlePatientAdultPatientMap)
        {
            _context.Add(littlePatientAdultPatientMap);
        }

        public async Task<LittlePatientAdultPatientMap?> FindByPatientIdAndRole(int patientId, string role)
        {
            if (role.Equals(Role.AdultPatient))
            {
                return await _context.LittlePatientAdultPatientMaps
                    .FirstOrDefaultAsync(map => map.AdultPatientId == patientId);
            }
            else if (role.Equals(Role.LittlePatient))
            {
                return await _context.LittlePatientAdultPatientMaps
                    .FirstOrDefaultAsync(map => map.LittlePatientId == patientId);
            }
            else
            {
                return null;
            }
        }
    }
}
