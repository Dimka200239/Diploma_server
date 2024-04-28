using App.Common.Interfaces.Persistence;
using Domain.Classes.AppDBClasses;
using MediatR;

namespace App.Lifestyles.Command.CreateLifestyle
{
    public class CreateLifestyleCommandHandler
        : IRequestHandler<CreateLifestyleCommand, CreateLifestyleResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateLifestyleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateLifestyleResult> Handle(
            CreateLifestyleCommand request,
            CancellationToken cancellationToken)
        {
            var lifestyle = new Lifestyle
            {
                PatientId = request.PatientId,
                Role = request.Role,
                SmokeCigarettes = request.SmokeCigarettes,
                DrinkAlcohol = request.DrinkAlcohol,
                Sport = request.Sport,
                DateOfChange = DateTime.UtcNow
            };

            _unitOfWork.Lifestyles.Add(lifestyle);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
                return new CreateLifestyleResult
                {
                    Success = false,
                    Errors = new List<string>() { "Не удалось сохранить данные в БД" }
                };

            return new CreateLifestyleResult
            {
                Success = true,
                Lifestyle = lifestyle
            };
        }
    }
}
