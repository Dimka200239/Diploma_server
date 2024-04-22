using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace server.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        [Authorize]
        protected string? GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        protected string? GetUserRole()
        {
            return User.FindFirst(ClaimTypes.Role)?.Value;
        }
    }
}
