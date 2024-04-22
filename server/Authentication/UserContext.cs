using System.Security.Claims;
using App.Common.Interfaces.Authentication;
using Domain.Models.User;

namespace server.Authentication
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="httpContextAccessor">Адаптер Http-context'а</param>
        public UserContext(IHttpContextAccessor httpContextAccessor)
            => _httpContextAccessor = httpContextAccessor;

        public int CurrentUserId
        {
            get
            {
                var result = int.TryParse(User?.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var userId);
                return result ? userId : -1;
            }
        }

        public bool IsEmployee
        {
            get
            {
                var result = User?.IsInRole(Role.Employee) ?? false;
                return result;
            }
        }

        public bool IsAdultPatient
        {
            get
            {
                var result = User?.IsInRole(Role.AdultPatient) ?? false;
                return result;
            }
        }

        public bool IsLittlePatient
        {
            get
            {
                var result = User?.IsInRole(Role.LittlePatient) ?? false;
                return result;
            }
        }

        public bool IsAdmin
        {
            get
            {
                var result = User?.IsInRole(Role.Admin) ?? false;
                return result;
            }
        }

        public bool IsAnonimus => !(IsEmployee || IsAdultPatient || IsLittlePatient || IsAdmin);

        private ClaimsPrincipal? User => _httpContextAccessor.HttpContext?.User;
    }
}
