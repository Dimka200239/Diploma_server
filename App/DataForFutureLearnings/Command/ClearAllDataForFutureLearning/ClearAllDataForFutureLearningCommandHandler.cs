using App.Common.Interfaces.Persistence;
using MediatR;

namespace App.DataForFutureLearnings.Command.ClearAllDataForFutureLearning
{
    public class ClearAllDataForFutureLearningCommandHandler
        : IRequestHandler<ClearAllDataForFutureLearningCommand, ClearAllDataForFutureLearningResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClearAllDataForFutureLearningCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ClearAllDataForFutureLearningResult> Handle(
            ClearAllDataForFutureLearningCommand request,
            CancellationToken cancellationToken)
        {
            _unitOfWork.DataForFutureLearnings.ClearAll();

            var result = await _unitOfWork.CompleteAsync();

            if (!result)
                return new ClearAllDataForFutureLearningResult
                {
                    Success = false,
                    Errors = new List<string>() { "Не удалось удалить данные из БД" }
                };

            return new ClearAllDataForFutureLearningResult
            {
                Success = true
            };
        }
    }
}
