using App.Common.Interfaces.Persistence;
using MediatR;

namespace App.LittlePatients.Command.UpdateLittlePatient
{
    public class UpdateLittlePatientCommandHandler
        : IRequestHandler<UpdateLittlePatientCommand, UpdateLittlePatientResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateLittlePatientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateLittlePatientResult> Handle(
            UpdateLittlePatientCommand request,
            CancellationToken cancellationToken)
        {
            var littlePatient = await _unitOfWork.LittlePatients.FindById(request.LittlePatientId);

            if (littlePatient is null)
                return new UpdateLittlePatientResult
                {
                    Success = false,
                    Errors = new List<string>() { "Не удалось найти данные" }
                };

            littlePatient.Name = request.Name;
            littlePatient.MiddleName = request.MiddleName;
            littlePatient.LastName = request.LastName;

            _unitOfWork.LittlePatients.Update(littlePatient);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
                return new UpdateLittlePatientResult
                {
                    Success = false,
                    Errors = new List<string>() { "Не удалось сохранить данные в БД" }
                };

            return new UpdateLittlePatientResult
            {
                Success = true,
                LittlePatient = littlePatient
            };
        }
    }
}
