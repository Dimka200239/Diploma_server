using App.Common.Interfaces.Persistence;
using MediatR;

namespace App.DataForFutureLearnings.Query.GetAllDataForFutureLearning
{
    public class GetAllDataForFutureLearningQueryHandler
        : IRequestHandler<GetAllDataForFutureLearningQuery, GetAllDataForFutureLearningResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllDataForFutureLearningQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetAllDataForFutureLearningResult> Handle(
            GetAllDataForFutureLearningQuery request,
            CancellationToken cancellationToken)
        {
            var dataForFutureLearnings = await _unitOfWork.DataForFutureLearnings.FindAll();

            if (dataForFutureLearnings is null)
                return new GetAllDataForFutureLearningResult
                {
                    Success = false,
                    Errors = new List<string>() { "Не удалось найти данные" }
                };

            var result = new GetAllDataForFutureLearningResult
            {
                Success = true,
                DataForFutureLearnings = dataForFutureLearnings
            };

            return result;
        }
    }
}
