using App.Common.Interfaces.Persistence;

namespace Infrastructure.Persistence.DB.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        private IEmployeeRepository _employeeRepository;
        private IRefreshTokenRepository _refreshTokenRepository;
        private IAdultPatientRepository _adultPatientRepository;
        private IPassportRepository _passportRepository;
        private IAddressRepository _addressRepository;
        private IAnthropometryOfPatientRepository _anthropometryOfPatientRepository;
        private ILifestyleRepository _lifestyleRepository;
        private IBloodAnalysisRepository _bloodAnalysisRepository;
        private IDateForForecastingRepository _dateForForecastingRepository;
        private IDataForFutureLearningRepository _dataForFutureLearningRepository;
        private IMachineLearningModelRepository _machineLearningModelRepository;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        public IEmployeeRepository Employees => _employeeRepository ?? (_employeeRepository = new EmployeeRepository(_context));
        public IRefreshTokenRepository RefreshTokens => _refreshTokenRepository ?? (_refreshTokenRepository = new RefreshTokenRepository(_context));
        public IAdultPatientRepository AdultPatients => _adultPatientRepository ?? (_adultPatientRepository = new AdultPatientRepository(_context));
        public IPassportRepository Passports => _passportRepository ?? (_passportRepository = new PassportRepository(_context));
        public IAddressRepository Adresses => _addressRepository ?? (_addressRepository = new AddressRepository(_context));
        public IAnthropometryOfPatientRepository AnthropometryOfPatients => _anthropometryOfPatientRepository ?? (_anthropometryOfPatientRepository = new AnthropometryOfPatientRepository(_context));
        public ILifestyleRepository Lifestyles => _lifestyleRepository ?? (_lifestyleRepository = new LifestyleRepository(_context));
        public IBloodAnalysisRepository BloodAnalysises => _bloodAnalysisRepository ?? (_bloodAnalysisRepository = new BloodAnalysisRepository(_context));
        public IDateForForecastingRepository DateForForecastings => _dateForForecastingRepository ?? (_dateForForecastingRepository = new DateForForecastingRepository(_context));
        public IDataForFutureLearningRepository DataForFutureLearnings => _dataForFutureLearningRepository ?? (_dataForFutureLearningRepository = new DataForFutureLearningRepository(_context));
        public IMachineLearningModelRepository MachineLearningModels => _machineLearningModelRepository ?? (_machineLearningModelRepository = new MachineLearningModelRepository(_context));

        public async Task<bool> CompleteAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        private bool _disposed;

        protected virtual async ValueTask DisposeAsync(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    await _context.DisposeAsync();
                }

                _disposed = true;
            }
        }
    }
}
