using App.Common.Interfaces.Persistence;
using MediatR;

namespace App.MachineLearningModels.Query.GetLastVersion
{
    public class GetLastVersionQueryHandler
        : IRequestHandler<GetLastVersionQuery, GetLastVersionResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetLastVersionQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetLastVersionResult> Handle(
            GetLastVersionQuery request,
            CancellationToken cancellationToken)
        {
            var machineLearningModels = await _unitOfWork.MachineLearningModels.GetLastVersion();

            if (machineLearningModels is null)
                return new GetLastVersionResult
                {
                    Success = false,
                    Errors = new List<string>() { "Не удалось найти данные о математической модели" }
                };

            var result = new GetLastVersionResult
            {
                Success = true,
                MachineLearningModel = machineLearningModels
            };

            return result;
        }
    }
}
