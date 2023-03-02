using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Users.Register
{
    public class RegisterUserCommandValidator:AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(r => r.PhoneNumber)
                .NotEmpty().WithMessage(ValidationMessages.required("شماره تلفن"))
                .NotNull().WithMessage(ValidationMessages.required("شماره تلفن"))
                .MinimumLength(4).WithMessage(ValidationMessages.required("شماره تلفن"));
                }
    }
}
