using App.Common.Interfaces.Persistence;
using Domain.Classes;
using Domain.Classes.AppDBClasses;
using MediatR;

namespace App.Passports.Command.CreatePassport
{
    public class CreatePassportCommandHandler
        : IRequestHandler<CreatePassportCommand, CreatePassportResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePassportCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreatePassportResult> Handle(
            CreatePassportCommand request,
            CancellationToken cancellationToken)
        {
            var timeRegistration = request.DateOfIssue;
            var hashSeries = new HashSecurity(request.Series, timeRegistration);
            var hashNumber = new HashSecurity(request.Number, timeRegistration);
            var hashCode = new HashSecurity(request.Code, timeRegistration);

            var passport = new Passport
            {
                AdultPatientId = request.AdultPatientId,
                Series = hashSeries.Text,
                Number = hashNumber.Text,
                Code = hashCode.Text,
                DateOfIssue = request.DateOfIssue
            };

            _unitOfWork.Passports.Add(passport);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
                return new CreatePassportResult
                {
                    Success = false,
                    Errors = new List<string>() { "Не удалось сохранить данные в БД" }
                };

            return new CreatePassportResult
            {
                Success = true,
                Passport = passport
            };
        }
    }
}
