using FluentValidation;

namespace App.Auth.Queries.Login
{
    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty().WithMessage("Логин не должен быть пустым");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Пароль не должен быть пустым");
        }

    }
}
