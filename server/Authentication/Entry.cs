using App.Common.Interfaces.Authentication;

namespace server.Authentication
{
    public static class Entry
    {
        /// <summary>
        /// Добавить контекст пользователя в службы приложения
        /// </summary>
        /// <param name="services">Службы приложения</param>
        /// <returns>Службы приложения с контекстом текущего пользователя</returns>
        public static IServiceCollection AddUserContext(this IServiceCollection services) =>
            services
                .AddScoped<IUserContext, UserContext>();
    }
}
