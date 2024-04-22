namespace App.Common.Exceptions.Profile
{
    public class ProfileAlreadyExistsException : Exception
    {
        public ProfileAlreadyExistsException()
            : base($"Профиль уже существует.") { }
    }
}
