namespace App.Common.Interfaces.Persistence
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employees { get; }
        IRefreshTokenRepository RefreshTokens { get; }
        IAdultPatientRepository AdultPatients { get; }
        IPassportRepository Passports { get; }
        IAddressRepository Adresses { get; }
        IAnthropometryOfPatientRepository AnthropometryOfPatients { get; }
        ILifestyleRepository Lifestyles { get; }
        IBloodAnalysisRepository BloodAnalysises { get; }
        IBirthCertificateRepository BirthCertificates { get; }
        ILittlePatientRepository LittlePatients { get; }
        ILittlePatientAdultPatientMapReposirory LittlePatientAdultPatientMaps{ get; }
        Task<bool> CompleteAsync();
    }
}
