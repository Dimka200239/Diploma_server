using App.Common.Interfaces.Persistence;
using Domain.Classes.AppDBClasses;
using MediatR;

namespace App.DataForFutureLearnings.Command.CreateDataForFutureLearning
{
    public class CreateDataForFutureLearningCommandHandler
        : IRequestHandler<CreateDataForFutureLearningCommand, CreateDataForFutureLearningResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateDataForFutureLearningCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateDataForFutureLearningResult> Handle(
            CreateDataForFutureLearningCommand request,
            CancellationToken cancellationToken)
        {
            var newDataForFutureLearning = new DataForFutureLearning
            {
                Gender = request.Gender,
                Age = request.Age,
                SmokeCigarettes = request.SmokeCigarettes,
                DrinkAlcohol = request.DrinkAlcohol,
                Sport = request.Sport,
                AmountOfCholesterol = request.AmountOfCholesterol,
                HDL = request.HDL,
                LDL = request.LDL,
                AtherogenicityCoefficient = request.AtherogenicityCoefficient,
                WHI = request.WHI,
                HasCVD = request.HasCVD
            };

            _unitOfWork.DataForFutureLearnings.Add(newDataForFutureLearning);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
                return new CreateDataForFutureLearningResult
                {
                    Success = false,
                    Errors = new List<string>() { "Не удалось сохранить данные об анализе в БД" }
                };

            return new CreateDataForFutureLearningResult
            {
                Success = true
            };
        }
    }
}
