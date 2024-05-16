using App.Common.Interfaces.Persistence;
using MediatR;

namespace App.DateForForecastings.Command.AddDateForForecasting
{
    public class AddDateForForecastingCommandHandler
        : IRequestHandler<AddDateForForecastingCommand, AddDateForForecastingResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddDateForForecastingCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AddDateForForecastingResult> Handle(
            AddDateForForecastingCommand request,
            CancellationToken cancellationToken)
        {
            if (request.DateForForecastingList is not null)
            {
                if (request.DateForForecastingList.Count == 0)
                    return new AddDateForForecastingResult
                    {
                        Success = false,
                        Errors = new List<string>() { "Вы не отправили данные" }
                    };

                _unitOfWork.DateForForecastings.AddRange(request.DateForForecastingList);
                var result = await _unitOfWork.CompleteAsync();

                if (!result)
                    return new AddDateForForecastingResult
                    {
                        Success = false,
                        Errors = new List<string>() { "Не удалось сохранить данные в БД" }
                    };

                return new AddDateForForecastingResult
                {
                    Success = true
                };
            }

            return new AddDateForForecastingResult
            {
                Success = false,
                Errors = new List<string>() { "Вы не отправили данные" }
            };
        }
    }
}
