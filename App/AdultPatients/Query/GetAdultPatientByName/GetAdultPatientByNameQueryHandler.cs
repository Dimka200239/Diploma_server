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
            var adultPatients = await _unitOfWork.AdultPatients.FindByName(request.Name.Split(" "));

            if (adultPatients is null)
            {
                return new GetAdultPatientByNameResult
                {
                    Success = false,
                    Errors = new List<string>() { "Не удалось найти данные" }
                };
            }

            if (adultPatients.Count == 0)
            {
                return new GetAdultPatientByNameResult
                {
                    Success = false,
                    Errors = new List<string>() { "Не удалось найти данные" }
                };
            }

            var result = new GetAdultPatientByNameResult();
            result.AdultPatients = new List<GetPatientWithAddressItemList>();
            result.Success = true;

            foreach (var item in adultPatients)
            {
                var getPatientWithAddressItemList = new GetPatientWithAddressItemList();
                getPatientWithAddressItemList.AdultPatient = item;
                getPatientWithAddressItemList.Address = item.Addresses.OrderByDescending(a => a.DateOfChange).FirstOrDefault();

                result.AdultPatients.Add(getPatientWithAddressItemList);
            }

            return result;
        }
    }
}
