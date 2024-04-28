using Domain.Classes.AppDBClasses;

namespace App.Common.Interfaces.Persistence
{
    public interface ILittlePatientAdultPatientMapReposirory
    {
        Task<LittlePatientAdultPatientMap?> FindByPatientIdAndRole(int patientId, string role);
        void Add(LittlePatientAdultPatientMap littlePatientAdultPatientMap);
    }
}
