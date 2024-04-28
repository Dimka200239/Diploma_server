using App.Common.Interfaces.Persistence;
using MediatR;

namespace App.BloodAnalysises.Query.GetAllBloodAnalysises
{
    public class GetAllBloodAnalysisesQueryHandler
        : IRequestHandler<GetAllBloodAnalysisesQuery, GetAllBloodAnalysisesResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllBloodAnalysisesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetAllBloodAnalysisesResult> Handle(
            GetAllBloodAnalysisesQuery request,
            CancellationToken cancellationToken)
        {
            var bloodAnalyses = await _unitOfWork.BloodAnalysises.FindAll(request.ParientId, request.Role);

            if (bloodAnalyses is null)
                return new GetAllBloodAnalysisesResult
                {
                    Success = false,
                    Errors = new List<string>() { "Не удалось найти данные" }
                };

            var result = new GetAllBloodAnalysisesResult
            {
                Success = true,
                BloodAnalysises = bloodAnalyses
            };

            return result;
        }
    }
}
