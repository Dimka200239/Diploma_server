using App.Common.Interfaces.Persistence;
using Domain.Classes.AppDBClasses;
using MediatR;

namespace App.LittlePatients.Command.CreateLittlePatient
{
    public class CreateLittlePatientCommandHandler
        : IRequestHandler<CreateLittlePatientCommand, CreateLittlePatientResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateLittlePatientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateLittlePatientResult> Handle(
            CreateLittlePatientCommand request,
            CancellationToken cancellationToken)
        {
            var littlePatient = new LittlePatient
            {
                Name = request.Name,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,
                Role = request.Role
            };

            _unitOfWork.LittlePatients.Add(littlePatient);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
                return new CreateLittlePatientResult
                {
                    Success = false,
                    Errors = new List<string>() { "Не удалось сохранить данные в БД" }
                };

            return new CreateLittlePatientResult
            {
                Success = true,
                LittlePatientId = littlePatient.Id
            };
        }
    }
}
