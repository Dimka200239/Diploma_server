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
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Не нашел пользователя");
                Console.WriteLine();
                Console.WriteLine();
                return new AuthResult { Success = false, Errors = new List<string> { "Неверные учетные данные" } };
            }

            var hashRequest = new HashSecurity(request.Password, employee.RegistrationDate.AddHours(3));
            var hashRequest2 = new HashSecurity(request.Password, employee.RegistrationDate.ToUniversalTime());

            if (employee.Password == hashRequest.Text || employee.Password == hashRequest2.Text)
            {
                var refreshToken = _jwtTokenGenerator.GenerateRefreshToken();

                employee.RefreshTokens.Add(refreshToken);
                await _unitOfWork.CompleteAsync();

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(employee.Password);
                Console.WriteLine(hashRequest.Text);
                Console.WriteLine(hashRequest2.Text);
                Console.WriteLine(employee.RegistrationDate);
                Console.WriteLine(employee.RegistrationDate.ToUniversalTime());
                Console.WriteLine();
                Console.WriteLine();

                return new AuthResult
                {
                    Success = true,
                    Token = _jwtTokenGenerator.GenerateToken(employee),
                    Role = employee.Role,
                    RefreshToken = refreshToken.Token,
                    RefreshTokenExpiration = refreshToken.Expires,
                    Login = employee.Login
                };
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(employee.Password);
                Console.WriteLine(hashRequest.Text);
                Console.WriteLine(hashRequest.Text);
                Console.WriteLine(hashRequest2.Text);
                Console.WriteLine(employee.RegistrationDate);
                Console.WriteLine(employee.RegistrationDate.ToUniversalTime());
                Console.WriteLine();
                Console.WriteLine();
                return new AuthResult { Success = false, Errors = new List<string> { "Неверные учетные данные" } };
            }
        }
    }
}
