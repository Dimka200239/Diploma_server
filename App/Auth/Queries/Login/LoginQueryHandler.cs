using App.Auth.Common;
using App.Common.Interfaces.Authentication;
using App.Common.Interfaces.Persistence;
using Domain.Classes;
using MediatR;
using Microsoft.Extensions.Logging;

namespace App.Auth.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenGenerator _jwtTokenGenerator;

        public LoginQueryHandler(IUnitOfWork unitOfWork, ITokenGenerator jwtTokenGenerator)
        {
            _unitOfWork = unitOfWork;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<AuthResult> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var employee = await _unitOfWork.Employees.FindByLogin(request.Login);

            if (employee is null)
                return new AuthResult { Success = false, Errors = new List<string> { "Неверные учетные данные" } };

            var hashRequest = new HashSecurity(request.Password, employee.RegistrationDate);
            var hashRequest2 = new HashSecurity(request.Password, employee.RegistrationDate.ToUniversalTime());

            if (employee.Password == hashRequest.Text || employee.Password == hashRequest2.Text)
            {
                var refreshToken = _jwtTokenGenerator.GenerateRefreshToken();

                employee.RefreshTokens.Add(refreshToken);
                await _unitOfWork.CompleteAsync();

                return new AuthResult
                {
                    Success = true,
                    Token = _jwtTokenGenerator.GenerateToken(employee),
                    Role = employee.Role,
                    RefreshToken = refreshToken.Token,
                    RefreshTokenExpiration = refreshToken.Expires
                };
            }
            else
            {
                return new AuthResult { Success = false, Errors = new List<string> { "Неверные учетные данные" } };
            }
        }
    }
}
