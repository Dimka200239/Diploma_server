using MediatR;

namespace App.Auth.Commands.RevokeToken
{
    public class RevokeTokenCommand : IRequest<RevokeTokenResult>
    {
        public string Token { get; set; }
    }
}
