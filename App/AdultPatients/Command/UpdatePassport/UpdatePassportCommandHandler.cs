using App.AdultPatients.Command.UpdateAdultPatient;
using App.Common.Interfaces.Persistence;
using Domain.Classes.AppDBClasses;
using MediatR;

namespace App.AdultPatients.Command.UpdatePassport
{
    public class UpdatePassportCommandHandler
        : IRequestHandler<UpdatePassportCommand, UpdatePassportResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePassportCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdatePassportResult> Handle(
            UpdatePassportCommand request,
            CancellationToken cancellationToken)
        {
            var passport = await _unitOfWork.Passports.FindByAdultPatientId(request.AdultPatientId);

            if (passport is null)
                return new UpdatePassportResult
                {
                    Success = false,
                    Errors = new List<string>() { "Не удалось найти данные" }
                };

            passport.Series = request.NewSeries;
            passport.Number = request.NewNumber;
            passport.Code = request.NewCode;
            passport.DateOfIssue = request.NewDateOfIssue;

            _unitOfWork.Passports.Update(passport);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
                return new UpdatePassportResult
                {
                    Success = false,
                    Errors = new List<string>() { "Не удалось сохранить данные в БД" }
                };

            return new UpdatePassportResult
            {
                Success = true,
                Passport = passport
            };
        }
    }
}
