using App.Common.Interfaces.Persistence;
using MediatR;

namespace App.Auth.Commands.RevokeToken
{
    public class RevokeTokenCommandHandler : IRequestHandler<RevokeTokenCommand, RevokeTokenResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RevokeTokenCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RevokeTokenResult> Handle(RevokeTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Employees.GetUserCheckToken(request.Token);

            if (user is null)
                return new RevokeTokenResult
                {
                    Success = false,
                    Errors = new List<string> { "Для данного токена не найден пользователь" }
                };

            var refreshToken = user.RefreshTokens.Single(x => x.Token == request.Token);

            if (refreshToken == null || !refreshToken.IsActive())
            {
                return new RevokeTokenResult
                {
                    Success = false,
                    Errors = new List<string> { "Токен не действителен" }
                };
            }

            _unitOfWork.RefreshTokens.Remove(refreshToken);

            await _unitOfWork.CompleteAsync();

            return new RevokeTokenResult
            {
                Success = true,
            };
        }
    }
}
