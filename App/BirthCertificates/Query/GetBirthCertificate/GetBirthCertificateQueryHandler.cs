using App.Common.Interfaces.Persistence;
using MediatR;

namespace App.BirthCertificates.Query.GetBirthCertificate
{
    public class GetBirthCertificateQueryHandler
        : IRequestHandler<GetBirthCertificateQuery, GetBirthCertificateResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBirthCertificateQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetBirthCertificateResult> Handle(
            GetBirthCertificateQuery request,
            CancellationToken cancellationToken)
        {
            var birthCertificate = await _unitOfWork.BirthCertificates.FindByLittlePatientId(request.LittlePatientId);

            if (birthCertificate is null)
                return new GetBirthCertificateResult
                {
                    Success = false,
                    Errors = new List<string>() { "Не удалось найти данные" }
                };

            var result = new GetBirthCertificateResult
            {
                Success = true,
                BirthCertificates = birthCertificate
            };

            return result;
        }
    }
}
