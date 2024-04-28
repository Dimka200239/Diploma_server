using App.Common.Interfaces.Persistence;
using MediatR;

namespace App.LittlePatientAdultPatientMaps.Query.FindByPatientIdAndRole
{
    public class FindByPatientIdAndRoleQueryHandler
        : IRequestHandler<FindByPatientIdAndRoleQuery, FindByPatientIdAndRoleResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public FindByPatientIdAndRoleQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FindByPatientIdAndRoleResult> Handle(
            FindByPatientIdAndRoleQuery request,
            CancellationToken cancellationToken)
        {
            var littlePatientAdultPatientMap = await _unitOfWork.LittlePatientAdultPatientMaps.FindByPatientIdAndRole(request.PatientId, request.Role);

            if (littlePatientAdultPatientMap is null)
                return new FindByPatientIdAndRoleResult
                {
                    Success = false,
                    Errors = new List<string>() { "Не удалось найти данные" }
                };

            var result = new FindByPatientIdAndRoleResult
            {
                Success = true,
                LittlePatientAdultPatientMap = littlePatientAdultPatientMap
            };

            return result;
        }
    }
}
