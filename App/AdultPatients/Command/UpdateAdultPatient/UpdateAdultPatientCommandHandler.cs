using App.Common.Interfaces.Persistence;
using MediatR;

namespace App.AdultPatients.Command.UpdateAdultPatient
{
    public class UpdateAdultPatientCommandHandler
        : IRequestHandler<UpdateAdultPatientCommand, UpdateAdultPatientResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAdultPatientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateAdultPatientResult> Handle(
            UpdateAdultPatientCommand request,
            CancellationToken cancellationToken)
        {
            var adultPatient = await _unitOfWork.AdultPatients.FindById(request.AdultPatientId);

            if (adultPatient is null)
                return new UpdateAdultPatientResult
                {
                    Success = false,
                    Errors = new List<string>() { "Не удалось найти данные" }
                };

            adultPatient.Name = request.Name;
            adultPatient.MiddleName = request.MiddleName;
            adultPatient.LastName = request.LastName;
            adultPatient.PhoneNumber = request.PhoneNumber;

            _unitOfWork.AdultPatients.Update(adultPatient);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
                return new UpdateAdultPatientResult
                {
                    Success = false,
                    Errors = new List<string>() { "Не удалось сохранить данные в БД" }
                };

            return new UpdateAdultPatientResult
            {
                Success = true,
                AdultPatient = adultPatient
            };
        }
    }
}
