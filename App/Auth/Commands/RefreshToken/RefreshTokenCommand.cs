using App.Auth.Common;
using MediatR;

namespace App.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommand : IRequest<AuthResult>
    {
        public string UserId { get; set; }
        public string Token { get; set; }
    }
}
