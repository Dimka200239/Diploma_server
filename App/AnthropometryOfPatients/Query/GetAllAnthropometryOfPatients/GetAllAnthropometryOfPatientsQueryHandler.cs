using App.Adresses.Query.GetAllAddresses;
using App.Common.Interfaces.Persistence;
using MediatR;

namespace App.AnthropometryOfPatients.Query.GetAllAnthropometryOfPatients
{
    public class GetAllAnthropometryOfPatientsQueryHandler
        : IRequestHandler<GetAllAnthropometryOfPatientsQuery, GetAllAnthropometryOfPatientsResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllAnthropometryOfPatientsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetAllAnthropometryOfPatientsResult> Handle(
            GetAllAnthropometryOfPatientsQuery request,
            CancellationToken cancellationToken)
        {
            var anthropometryOfPatients = await _unitOfWork.AnthropometryOfPatients.FindAll(request.ParientId, request.Role);

            if (anthropometryOfPatients is null)
                return new GetAllAnthropometryOfPatientsResult
                {
                    Success = false,
                    Errors = new List<string>() { "Не удалось найти данные" }
                };

            var result = new GetAllAnthropometryOfPatientsResult
            {
                Success = true,
                AnthropometryOfPatients = anthropometryOfPatients
            };

            return result;
        }
    }
}
