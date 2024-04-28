using App.Common.Interfaces.Persistence;
using Domain.Classes.AppDBClasses;
using MediatR;

namespace App.Adresses.Query.GetAllAddresses
{
    public class GetAllAddressesQueryHandler
        : IRequestHandler<GetAllAddressesQuery, GetAllAddressesResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllAddressesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetAllAddressesResult> Handle(
            GetAllAddressesQuery request,
            CancellationToken cancellationToken)
        {
            var adresses = await _unitOfWork.Adresses.FindAll(request.ParientId, request.Role);

            if (adresses is null)
                return new GetAllAddressesResult
                {
                    Success = false,
                    Errors = new List<string>() { "Не удалось найти данные" }
                };

            var result = new GetAllAddressesResult
            {
                Success = true,
                Addresses = adresses
            };

            return result;
        }
    }
}
