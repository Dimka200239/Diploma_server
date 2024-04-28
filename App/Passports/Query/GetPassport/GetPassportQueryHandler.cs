using App.Common.Interfaces.Persistence;
using MediatR;

namespace App.Passports.Query.GetPassport
{
    public class GetPassportQueryHandler
        : IRequestHandler<GetPassportQuery, GetPassportResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPassportQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetPassportResult> Handle(
            GetPassportQuery request,
            CancellationToken cancellationToken)
        {
            var passport = await _unitOfWork.Passports.FindByAdultPatientId(request.AdultPatientId);

            if (passport is null)
                return new GetPassportResult
                {
                    Success = false,
                    Errors = new List<string>() { "Не удалось найти данные" }
                };

            var result = new GetPassportResult
            {
                Success = true,
                Passport = passport
            };

            return result;
        }
    }
}
