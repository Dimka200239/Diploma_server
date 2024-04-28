using App.Common.Interfaces.Persistence;
using MediatR;

namespace App.Lifestyles.Query.GetAllLifestyles
{
    public class GetAllLifestylesQueryHandker
        : IRequestHandler<GetAllLifestylesQuery, GetAllLifestylesResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllLifestylesQueryHandker(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetAllLifestylesResult> Handle(
            GetAllLifestylesQuery request,
            CancellationToken cancellationToken)
        {
            var lifestyles = await _unitOfWork.Lifestyles.FindAll(request.ParientId, request.Role);

            if (lifestyles is null)
                return new GetAllLifestylesResult
                {
                    Success = false,
                    Errors = new List<string>() { "Не удалось найти данные" }
                };

            var result = new GetAllLifestylesResult
            {
                Success = true,
                Lifestyles = lifestyles
            };

            return result;
        }
    }
}
