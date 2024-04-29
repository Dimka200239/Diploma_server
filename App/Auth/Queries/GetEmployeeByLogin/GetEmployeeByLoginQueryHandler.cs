using App.Common.Interfaces.Persistence;
using MediatR;

namespace App.Auth.Queries.GetEmployeeByLogin
{
    public class GetEmployeeByLoginQueryHandler
        : IRequestHandler<GetEmployeeByLoginQuery, GetEmployeeByLoginResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEmployeeByLoginQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetEmployeeByLoginResult> Handle(
            GetEmployeeByLoginQuery request,
            CancellationToken cancellationToken)
        {
            var employee = await _unitOfWork.Employees.FindByLogin(request.Login);

            if (employee is null)
                return new GetEmployeeByLoginResult
                {
                    Success = false,
                    Errors = new List<string>() { "Не удалось найти данные" }
                };

            var result = new GetEmployeeByLoginResult
            {
                Success = true,
                Employee = employee
            };

            return result;
        }
    }
}
