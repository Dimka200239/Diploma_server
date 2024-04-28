using App.Common.Interfaces.Persistence;
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
            var passport = new Passport
            {
                AdultPatientId = request.AdultPatientId,
                Series = request.Series,
                Number = request.Number,
                Code = request.Code,
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
