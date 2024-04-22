namespace App.Common.Exceptions.Person
{
    public class NotFoundPersonException : Exception
    {
        public NotFoundPersonException(string login)
            : base($"Человек с логином: \"{login}\" не найден.") { }
    }
}
