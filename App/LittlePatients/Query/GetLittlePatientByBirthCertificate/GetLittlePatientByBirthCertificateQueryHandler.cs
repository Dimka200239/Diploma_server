using App.Common.Interfaces.Persistence;
using MediatR;

namespace App.LittlePatients.Query.GetLittlePatientByBirthCertificate
{
    public class GetLittlePatientByBirthCertificateQueryHandler
        : IRequestHandler<GetLittlePatientByBirthCertificateQuery, GetLittlePatientByBirthCertificateResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetLittlePatientByBirthCertificateQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetLittlePatientByBirthCertificateResult> Handle(
            GetLittlePatientByBirthCertificateQuery request,
            CancellationToken cancellationToken)
        {
            var littlePatient = await _unitOfWork.LittlePatients.FindByBirthCertificate(request);

            if (littlePatient is null)
                return new GetLittlePatientByBirthCertificateResult
                {
                    Success = false,
                    Errors = new List<string>() { "Не удалось найти данные" }
                };

            var result = new GetLittlePatientByBirthCertificateResult
            {
                Success = true,
                LittlePatient = littlePatient
            };

            return result;
        }
    }
}
