using App.Auth.Common;
using MediatR;

namespace App.Auth.Commands.RegisterEmployee
{
    public class RegisterEmployeeCommand : IRequest<AuthResult>
    {
        public string Login { set; get; }

        public string Password { set; get; }

        public string Name { get; set; }

        public string? MiddleName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string Role { set; get; }

        public string? Token { get; set; } //Токен из ссылки для регистрации
    }
}
