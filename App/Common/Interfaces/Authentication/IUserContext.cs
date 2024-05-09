namespace App.Common.Interfaces.Authentication
{
    public interface IUserContext
    {
        /// <summary>
        /// ИД текущего пользователя
        /// </summary>
        int CurrentUserId { get; }

        bool IsEmployee { get; }

        bool IsAdultPatient { get; }

        bool IsAdmin { get; }

        /// <summary>
        /// Является ли анонимным пользователем
        /// </summary>
        bool IsAnonimus { get; }
    }
}
