using App.Common.Interfaces.Persistence;
using MediatR;

namespace App.AdultPatients.Query.GetAdultPatientByName
{
    public class GetAdultPatientByNameQueryHandler
        : IRequestHandler<GetAdultPatientByNameQuery, GetAdultPatientByNameResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAdultPatientByNameQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetAdultPatientByNameResult> Handle(
            GetAdultPatientByNameQuery request,
            CancellationToken cancellationToken)
        {
            var fullName = "";
            foreach (var el in request.Name.Split(" "))
            {
                fullName += el + " ";
            }

            var adultPatients = await _unitOfWork.AdultPatients.FindByName(fullName, request.DateOfBirth, request.Gender);

            if (adultPatients is null)
            {
                return new GetAdultPatientByNameResult
                {
                    Success = false,
                    Errors = new List<string>() { "Не удалось найти данные" }
                };
            }

            var result = new GetAdultPatientByNameResult
            {
                Success = true,
                AdultPatients = adultPatients
            };

            return result;
        }
    }
}
