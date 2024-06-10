using App.Auth.Common;
using App.Common.Interfaces.Authentication;
using App.Common.Interfaces.Persistence;
using App.Lifestyles.Command.CreateLifestyle;
using Domain.Classes;
using Domain.Classes.AppDBClasses;
using Domain.Models.User;
using MediatR;

namespace App.Auth.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler
        : IRequestHandler<UpdateEmployeeCommand, UpdateEmployeeResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenGenerator _tokenGenerator;

        public UpdateEmployeeCommandHandler(IUnitOfWork unitOfWork, ITokenGenerator tokenGenerator)
        {
            _unitOfWork = unitOfWork;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<UpdateEmployeeResult> Handle(
            UpdateEmployeeCommand request,
            CancellationToken cancellationToken)
        {
            if (request.Login is null)
                return new UpdateEmployeeResult
                {
                    Success = false,
                    Errors = new List<string> { "Не удалось найти данные" }
                };

            var employee = await _unitOfWork.Employees.FindByLogin(request.Login);

            if (employee is null)
                return new UpdateEmployeeResult
                {
                    Success = false,
                    Errors = new List<string> { "Не удалось найти данные" }
                };

            var timeRegistration = DateTime.UtcNow;
            var hash = new HashSecurity(request.Password, timeRegistration);
            var refreshToken = _tokenGenerator.GenerateRefreshToken();

            employee.Password = hash.Text;
            employee.Gender = request.Gender.Equals("Женщина") ? Gender.Female : Gender.Male;
            employee.Role = request.Role.Equals("employee") ? Role.Employee : Role.Admin;
            employee.Name = request.Name;
            employee.LastName = request.LastName;
            employee.MiddleName = request.MiddleName;
            employee.RegistrationDate = timeRegistration;

            employee.RefreshTokens.Add(refreshToken);

            _unitOfWork.Employees.Update(employee);

            var result = await _unitOfWork.CompleteAsync();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(employee.Password);
            Console.WriteLine(hash.Text);
            Console.WriteLine(timeRegistration);
            Console.WriteLine(timeRegistration.ToUniversalTime());
            Console.WriteLine(employee.RegistrationDate);
            Console.WriteLine();
            Console.WriteLine();

            if (result)
                return new UpdateEmployeeResult
                {
                    Success = true
                };
            else
                return new UpdateEmployeeResult
                {
                    Success = false,
                    Errors = new List<string> { "Не удалось сохранить данные" }
                };
        }
    }
}
