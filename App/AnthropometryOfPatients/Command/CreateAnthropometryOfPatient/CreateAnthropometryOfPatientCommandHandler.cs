using App.Adresses.Command.CreateAddress;
using App.Common.Interfaces.Persistence;
using Domain.Classes.AppDBClasses;
using MediatR;

namespace App.AnthropometryOfPatients.Command.CreateAnthropometryOfPatient
{
    public class CreateAnthropometryOfPatientCommandHandler
        : IRequestHandler<CreateAnthropometryOfPatientCommand, CreateAnthropometryOfPatientResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateAnthropometryOfPatientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateAnthropometryOfPatientResult> Handle(
            CreateAnthropometryOfPatientCommand request,
            CancellationToken cancellationToken)
        {
            var anthropometryOfPatient = new AnthropometryOfPatient
            {
                PatientId = request.PatientId,
                Role = request.Role,
                Height = request.Height,
                Weight = request.Weight,
                Age = request.Age,
                DateOfChange = DateTime.UtcNow
            };

            _unitOfWork.AnthropometryOfPatients.Add(anthropometryOfPatient);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
                return new CreateAnthropometryOfPatientResult
                {
                    Success = false,
                    Errors = new List<string>() { "Не удалось сохранить данные в БД" }
                };

            return new CreateAnthropometryOfPatientResult
            {
                Success = true,
                AnthropometryOfPatient = anthropometryOfPatient
            };
        }
    }
}
