using App.Common.Interfaces.Persistence;
using Domain.Classes.AppDBClasses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var result = new GetAdultPatientByPassportResult
            {
                Success = true,
                AdultPatient = adultPatient
            };

            return result;
        }
    }
}
