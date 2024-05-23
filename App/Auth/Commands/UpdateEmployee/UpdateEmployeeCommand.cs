using Domain.Classes.AppDBClasses;
using MediatR;

namespace App.Auth.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommand : IRequest<UpdateEmployeeResult>
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string? MiddleName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string Role { get; set; }
    }
}
