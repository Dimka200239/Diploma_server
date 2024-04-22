using App.Auth.Commands.RegisterEmployee;
using Domain.Models.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [AllowAnonymous]
    [Route("api/auth")]
    public class AuthController : ApiController
    {
        private readonly ISender _mediator;

        public AuthController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("registerEmployee")]
        public async Task<IActionResult> RegisterEmployee([FromBody] RegisterEmployeeRequest request)
        {
            var query = new RegisterEmployeeCommand
            {
                Login = request.Login,
                Password = request.Password,
                Name = request.Name,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                Gender = request.Gender.Equals(Gender.Female) ? Gender.Female : Gender.Male,
                Role = Role.Employee,
                Token = request.Token
            };

            var result = await _mediator.Send(query);

            if (result.Success)
                SetRefreshTokenInCookie(result.RefreshToken!);

            return Ok(result);
        }

        private void SetRefreshTokenInCookie(string refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.ToUniversalTime().AddDays(10),
                IsEssential = true,
                Path = "/"
            };
            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }
    }

    public class RegisterEmployeeRequest
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string? MiddleName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string? Token { get; set; } //Токен из ссылки для регистрации
    }
}
