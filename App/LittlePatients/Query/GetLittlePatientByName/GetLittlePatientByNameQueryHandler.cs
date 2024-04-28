using App.Common.Interfaces.Persistence;
using MediatR;

namespace App.LittlePatients.Query.GetLittlePatientByName
{
    public class GetLittlePatientByNameQueryHandler
        : IRequestHandler<GetLittlePatientByNameQuery, GetLittlePatientByNameResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetLittlePatientByNameQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetLittlePatientByNameResult> Handle(
            GetLittlePatientByNameQuery request,
            CancellationToken cancellationToken)
        {
            var fullName = "";
            foreach (var el in request.Name.Split(" "))
            {
                fullName += el + " ";
            }

            var littlePatients = await _unitOfWork.LittlePatients.FindByName(fullName, request.DateOfBirth, request.Gender);

            if (littlePatients is null)
            {
                return new GetLittlePatientByNameResult
                {
                    Success = false,
                    Errors = new List<string>() { "Не удалось найти данные" }
                };
            }

            var result = new GetLittlePatientByNameResult
            {
                Success = true,
                LittlePatients = littlePatients
            };

            return result;
        }
    }
}
