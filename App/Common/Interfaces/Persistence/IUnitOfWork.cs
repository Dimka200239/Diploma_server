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
        IDateForForecastingRepository DateForForecastings { get; }
        IDataForFutureLearningRepository DataForFutureLearnings { get; }
        IMachineLearningModelRepository MachineLearningModels { get; }
        Task<bool> CompleteAsync();
    }
}
