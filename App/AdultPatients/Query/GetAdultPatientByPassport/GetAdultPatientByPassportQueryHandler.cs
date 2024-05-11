using App.Common.Interfaces.Persistence;
using Domain.Classes.AppDBClasses;
using MediatR;

namespace App.AdultPatients.Query.GetAdultPatientByPassport
{
    public class GetAdultPatientByPassportQueryHandler
        : IRequestHandler<GetAdultPatientByPassportQuery, GetAdultPatientByPassportResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAdultPatientByPassportQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetAdultPatientByPassportResult> Handle(
            GetAdultPatientByPassportQuery request,
            CancellationToken cancellationToken)
        {
            var adultPatient = await _unitOfWork.AdultPatients.FindByPassport(request);

            if (adultPatient is null)
                return new GetAdultPatientByPassportResult
                {
                    Success = false,
                    Errors = new List<string>() { "Не удалось найти данные" }
                };

            var result = new GetAdultPatientByPassportResult();
            result.AdultPatients = new List<GetPatientWithAddressItemList>();
            result.Success = true;

            var getPatientWithAddressItemList = new GetPatientWithAddressItemList();
            getPatientWithAddressItemList.AdultPatient = adultPatient;
            getPatientWithAddressItemList.Address = adultPatient.Addresses.OrderByDescending(a => a.DateOfChange).FirstOrDefault();

            result.AdultPatients.Add(getPatientWithAddressItemList);

            return result;
        }
    }
}
