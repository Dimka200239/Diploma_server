using App.Auth.Common;
using MediatR;

namespace App.Auth.Queries.Login
{
    public class LoginQuery : IRequest<AuthResult>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
