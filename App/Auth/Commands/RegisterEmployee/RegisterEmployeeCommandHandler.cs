using App.Auth.Common;
using App.Common.Interfaces.Authentication;
using App.Common.Interfaces.Persistence;
using Domain.Classes;
using Domain.Classes.AppDBClasses;
using Domain.Models.User;
using MediatR;
using Microsoft.Extensions.Logging;

namespace App.Auth.Commands.RegisterEmployee
{
    public class RegisterEmployeeCommandHandler
        : IRequestHandler<RegisterEmployeeCommand, AuthResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenGenerator _tokenGenerator;

        public RegisterEmployeeCommandHandler(
            IUnitOfWork unitOfWork,
            ITokenGenerator tokenGenerator)
        {
            _unitOfWork = unitOfWork;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<AuthResult> Handle(RegisterEmployeeCommand request, CancellationToken cancellationToken)
        {
            var isContainsLogin = await _unitOfWork.Employees.ContainsLogin(request.Login);

            if (isContainsLogin)
                return new AuthResult
                {
                    Success = false,
                    Errors = new List<string> { "Такой логин уже используется" }
                };

            var timeRegistration = DateTime.Now.ToUniversalTime();
            var hash = new HashSecurity(request.Password, timeRegistration);
            var refreshToken = _tokenGenerator.GenerateRefreshToken();

            var newUser = new Employee
            {
                Login = request.Login,
                Password = hash.Text,
                RegistrationDate = timeRegistration,
                Role = request.Role,
                Name = request.Name,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                Gender = request.Gender,
            };
            newUser.RefreshTokens.Add(refreshToken);

            if (request.Role == Role.Employee)
            {
                _unitOfWork.Employees.Add(newUser);
            }
            else
            {
                _unitOfWork.Employees.Update(newUser);
            }

            //Отправление ссылки на почту для подтверждения пользователя
            //var sendResult = await _confirmEmailService.SendMessageAsync(newUser);

            var result = await _unitOfWork.CompleteAsync();

            if (result)
                return new AuthResult
                {
                    Success = true,
                    Token = _tokenGenerator.GenerateToken(newUser),
                    RefreshToken = refreshToken.Token,
                    RefreshTokenExpiration = refreshToken.Expires,
                    Role = newUser.Role
                };
            else
                return new AuthResult
                {
                    Success = false,
                    Errors = new List<string> { "Не удалось сохранить данные" }
                };
        }
    }
}
