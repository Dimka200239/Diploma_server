using App.Common.Interfaces.Persistence;
using MediatR;

namespace App.AdultPatients.Query.GetAdultPatientByIdWithAnthropometryAndLifestyle
{
    public class GetAdultPatientByIdWithAnthropometryAndLifestyleQueryHandler
        : IRequestHandler<GetAdultPatientByIdWithAnthropometryAndLifestyleQuery, GetAdultPatientByIdWithAnthropometryAndLifestyleResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAdultPatientByIdWithAnthropometryAndLifestyleQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetAdultPatientByIdWithAnthropometryAndLifestyleResult> Handle(
            GetAdultPatientByIdWithAnthropometryAndLifestyleQuery request,
            CancellationToken cancellationToken)
        {
            var adultPatient = await _unitOfWork.AdultPatients.FindById(request.AdultPatientId);

            if (adultPatient is null)
                return new GetAdultPatientByIdWithAnthropometryAndLifestyleResult
                {
                    Success = false,
                    Errors = new List<string>() { "Не удалось найти данные" }
                };

            var result = new GetAdultPatientByIdWithAnthropometryAndLifestyleResult
            {
                Success = true,
                AnthropometryOfPatient = adultPatient.AnthropometryOfPatients.OrderByDescending(a => a.DateOfChange).FirstOrDefault(),
                Lifestyle = adultPatient.Lifestyles.OrderByDescending(a => a.DateOfChange).FirstOrDefault()
            };

            return result;
        }
    }
}
