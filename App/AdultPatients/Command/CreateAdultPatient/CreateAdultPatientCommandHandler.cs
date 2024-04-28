using App.Common.Interfaces.Persistence;
using Domain.Classes.AppDBClasses;
using MediatR;

namespace App.AdultPatients.Command.CreateAdultPatient
{
    public class CreateAdultPatientCommandHandler
        : IRequestHandler<CreateAdultPatientCommand, CreateAdultPatientResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateAdultPatientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateAdultPatientResult> Handle(
            CreateAdultPatientCommand request,
            CancellationToken cancellationToken)
        {
            var adultPatient = new AdultPatient
            {
                Name = request.Name,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                PhoneNumber = request.PhoneNumber,
                Gender = request.Gender,
                Role = request.Role
            };

            _unitOfWork.AdultPatients.Add(adultPatient);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
                return new CreateAdultPatientResult
                {
                    Success = false,
                    Errors = new List<string>() { "Не удалось сохранить данные в БД" }
                };

            return new CreateAdultPatientResult
            {
                Success = true,
                AdultPatientId = adultPatient.Id
            };
        }
    }
}
