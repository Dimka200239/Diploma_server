using App.Common.Interfaces.Persistence;
using Domain.Classes.AppDBClasses;
using MediatR;

namespace App.BirthCertificates.Command.CreateBirthCertificate
{
    public class CreateBirthCertificateCommandHandler
        : IRequestHandler<CreateBirthCertificateCommand, CreateBirthCertificateResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBirthCertificateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateBirthCertificateResult> Handle(
            CreateBirthCertificateCommand request,
            CancellationToken cancellationToken)
        {
            var birthCertificate = new BirthCertificate
            {
                LittlePatientId = request.LittlePatientId,
                Series = request.Series,
                Number = request.Number,
                DateOfIssue = request.DateOfIssue
            };

            _unitOfWork.BirthCertificates.Add(birthCertificate);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
                return new CreateBirthCertificateResult
                {
                    Success = false,
                    Errors = new List<string>() { "Не удалось сохранить данные в БД" }
                };

            return new CreateBirthCertificateResult
            {
                Success = true,
                BirthCertificate = birthCertificate
            };
        }
    }
}
