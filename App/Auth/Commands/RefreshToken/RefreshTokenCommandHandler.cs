using App.Auth.Common;
using App.Common.Interfaces.Authentication;
using App.Common.Interfaces.Persistence;
using MediatR;

namespace App.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, AuthResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenGenerator _tokenGenerator;

        public RefreshTokenCommandHandler(IUnitOfWork unitOfWork, ITokenGenerator tokenGenerator)
        {
            _unitOfWork = unitOfWork;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<AuthResult> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Employees.GetUserCheckToken(request.Token);

            if (user is null)
                return new AuthResult
                {
                    Success = false,
                    Errors = new List<string> { "Для данного токена не найден пользователь" }
                };

            var refreshToken = user.RefreshTokens.Single(x => x.Token == request.Token);

            if (refreshToken == null || !refreshToken.IsActive())
            {
                return new AuthResult
                {
                    Success = false,
                    Errors = new List<string> { "Токен не действителен" }
                };
            }

            var newRefreshToken = _tokenGenerator.GenerateRefreshToken();
            user.RefreshTokens.Add(newRefreshToken);
            _unitOfWork.RefreshTokens.Remove(refreshToken);

            await _unitOfWork.CompleteAsync();

            return new AuthResult
            {
                Success = true,
                Token = _tokenGenerator.GenerateToken(user),
                RefreshToken = newRefreshToken.Token,
                RefreshTokenExpiration = newRefreshToken.Expires
            };
        }
    }
}
