using App.Common.Interfaces.Persistence;
using App.DataForFutureLearnings.Query.GetAllDataForFutureLearning;
using MediatR;

namespace App.Correlations.Query.GetLastCorrelationValue
{
    public class GetLastCorrelationValueQueryHandler
        : IRequestHandler<GetLastCorrelationValueQuery, GetLastCorrelationValueResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetLastCorrelationValueQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetLastCorrelationValueResult> Handle(
            GetLastCorrelationValueQuery request,
            CancellationToken cancellationToken)
        {
            var lastCorrelationValue = await _unitOfWork.CorrelationValues.GetLastVersion();

            if (lastCorrelationValue is null)
                return new GetLastCorrelationValueResult
                {
                    Success = false,
                    Errors = new List<string>() { "Не удалось найти данные" }
                };

            var result = new GetLastCorrelationValueResult
            {
                Success = true,
                CorrelationValue = lastCorrelationValue
            };

            return result;
        }
    }
}
